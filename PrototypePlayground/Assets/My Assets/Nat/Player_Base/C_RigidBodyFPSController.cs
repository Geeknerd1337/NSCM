/*******************************************************************************************************
* 
* ***NAME***
* FPSCharacterMovement.cs
* 
* ***DESCRIPTION***
* A simple all-in-one First-Person controller.
* 
* ***USAGE***
* Place this script onto a gameobject with rigidbody and capsule OR box collider components, with the main camera childed to this object.
* 
* ***AUTHOR***
* Natalie Soltis
* 
* ***PURPOSE***
* This code was written for an unreleased two-week long Game Jam project, which will eventually find a release on itch.io. 
*   It has seen extensive modifications to be compatible with NSCM.
* 
******************************************************************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//requirements for script
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class C_RigidBodyFPSController : MonoBehaviour
{
    //Static variables 

    private static float SPEED = 10f;

    private static float DEFAULT_MAX_DELTA = 50f;

    //Serialized vars

    /*
     * @name: playerSpeed
     * @desc: Speed for the player. Used to calculate speed, both on the ground and in the air.
     */
    [Header("Ground movement options")]
    [SerializeField]
    [Tooltip("The player's speed")]
    private float playerSpeed = SPEED;

    [SerializeField]
    [Tooltip("The max delta that can be applied when changing the player's direction.")]
    private float maxChangeDirDelta = DEFAULT_MAX_DELTA;

    [SerializeField]
    [Tooltip("The max delta that can be applied when stopping the player.")]
    private float maxStoppingDelta = DEFAULT_MAX_DELTA;

    /*
     * @name: maxYAngle
     * @desc: Max angle for the attached camera's y rotation. Will be used for both positive and negative values.
     */
    [SerializeField]
    [Tooltip("The angle the player can look up/down")]
    private float maxYAngle = 90f;

    /*
     * @name: jumpHeight
     * @desc: height that the player can jump. Applied with a twenty-times multiplier as a rigidbody.addforce().
     */
    [SerializeField]
    [Tooltip("Height the player can jump")]
    private float jumpHeight = 10f;

    /*
     * @name: sensitivity
     * @desc: way to modulate the sensitivity of the mouse input. 
     */
    [SerializeField]
    [Tooltip("The Sensitivity of the camera")]
    private float sensitivity = 1f;

    /*
     * @name: airControl
     * @desc: the amount of control the player has in the air. 0 is mone, 1 is full control.
     */
    [Header("Air control parameters")]
    [SerializeField]
    [Tooltip("How much air control the player has\n0: none\n 1: same control as on ground")]
    [Range(0.0f, 1.0f)]
    private float airControl = .25f;

    /*
     * @name: AirSpeed
     * @desc: maximum speed the player can go in the air.
     */
    [SerializeField]
    [Tooltip("How fast the player can go while not grounded.")]
    private float AirSpeed;

    /*
     * @name: displayDebugInfo
     * @desc: if we want to display debug information such as rays. Will eventually be attached to a larger debug manager.
     */
    [Header("Debug")]
    [SerializeField]
    [Tooltip("Wether to display debug info and renders")]
    private bool displayDebugInfo;

    /*
     * @name: groundedCheckdist
     * @desc: determines the length of the raycast operation duing the isGrounded() check.
     */
    [SerializeField]
    [Tooltip("length for raycast for jump, default value 1.5f")]
    private float groundedCheckdist = 1.5f;

    /*
     * @name: destroyOnLoad
     * @desc: if we want to destroy this gameobject when loading. Setting to true will run the DoNotDestroyOnLoad Unity function on this parent gameobject.
     */
    [Header("Load settings")]
    [SerializeField]
    [Tooltip("Wether to destroy or not destroy when loading the next level \n true: do destroy\nfalse: do not destroy")]
    private bool destroyOnLoad;

    /*
     * @name: TPPos
     * @desc: vector3 offset of the third person mode. Will be added or subtracted from the Camera's xyz when the third person function is called.
     */
    [Header("DEPRICATED")]
    [SerializeField]
    [Tooltip("Third-Person offset. Won't be used in NSCM but keeping it around for posterity.")]
    private Vector3 TPPos;



    //nonserialized vars
        
    /// <summary>
    /// container variable for the current rotation of the parent gameobject. Used to contain, manipulate, and apply modifiers.
    /// </summary>
    private Vector2 currentRotation;

    /// <summary>
    /// Camera Rotation. Used as a shortcut for the camera gameobject's rotation.
    /// </summary>
    private Vector2 cameraRot;

    /// <summary>
    /// Input Force container for new Input Engine. Contains the new values to be passed.
    /// </summary>
    private Vector2 moveInputForce;

    /// <summary>
    /// container variable for camera. Used to make calculation with camera look just a bit prettier.
    /// </summary>
    private GameObject cameraObject;

    /// <summary>
    /// xyz for the first person camera position. Used as placeholder until new camera righting is finished.
    /// </summary>
    private Vector3 FPPos;

    /// <summary>
    /// boolean to determine if the current state of the player character is third-person mode or not. Not gonna be used in NSCM
    /// </summary>
    public bool isTP;


    [NonSerialized]
    public GameObject target = null;



    // NOT USED IN CURRENT IT. MIGHT EVENTUALLY BE OPTED IN FOR NSCM.
    //private AnimationCurve currentCurve;


    //Awake is used to assign variables and statuses on the gameobject.
    private void Awake()
    {
        //set mass on rigidbody to ensure physics feel right.
        transform.GetComponent<Rigidbody>().mass = 1;

        cameraObject = transform.GetChild(0).gameObject;

        FPPos = cameraObject.transform.localPosition;

        currentRotation = cameraObject.transform.rotation.eulerAngles;

        GetComponent<CharacterController>();

        if (!destroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        moveInputForce = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        MoveCamera(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));

        if (Input.GetButtonDown("Jump")) Jump();

        print(transform.GetComponent<Rigidbody>().velocity);
    }

    private void FixedUpdate()
    {
        //We move the player in this fixedupdate to ensure we don't need to use DeltaTime, and also because it is a mass of physics calculations.
        movePlayer(moveInputForce);
    }

    /*
     * does WASD movement, both grounded and not.
     */
    private void movePlayer(Vector2 movementForce)
    {
        if (isGrounded())
        {
            //rampup calculation
            if (Mathf.Abs(moveInputForce.x) == 0 && Mathf.Abs(moveInputForce.y) == 0)
            {
                transform.GetComponent<Rigidbody>().velocity = new Vector3(Mathf.MoveTowards(transform.GetComponent<Rigidbody>().velocity.x, 0,
                Time.deltaTime * 50), transform.GetComponent<Rigidbody>().velocity.y, Mathf.MoveTowards(transform.GetComponent<Rigidbody>().velocity.z, 0, Time.deltaTime * maxStoppingDelta));
                return;
            }

            //OLD with curvefloat
            //curveFloat = Mathf.MoveTowards(curveFloat, playerSpeed, Time.deltaTime * 10);

            ////creation and assignment of new velocity, called transformForce.
            //Vector3 transformForce = transform.forward * movementForce.y + transform.right * movementForce.x;
            //transformForce = new Vector3(transformForce.normalized.x * curveFloat, transformForce.y, transformForce.normalized.z * curveFloat);
            //transformForce.y = transform.GetComponent<Rigidbody>().velocity.y;

            //nat - try to make the delta thing a bit more understandable. Maybe make a func that converts the delta into seconds to max speed. God knows how to do that but 
                //you can figure it out, you're a smart girl
            //modern without curvefloat
            Vector3 transformForce = transform.forward * movementForce.y + transform.right * movementForce.x;
            transformForce = new Vector3(transformForce.normalized.x, transformForce.y, transformForce.normalized.z);
            transformForce = Vector3.MoveTowards(transform.GetComponent<Rigidbody>().velocity, transformForce * playerSpeed, maxChangeDirDelta * Time.deltaTime);
            transformForce.y = transform.GetComponent<Rigidbody>().velocity.y;
            transform.GetComponent<Rigidbody>().velocity = transformForce;

            //old
            //transform.GetComponent<Rigidbody>().velocity = transformForce;

        }
        else
        {
            //If airborne

            transform.GetComponent<Rigidbody>().AddForce((transform.forward * movementForce.y * playerSpeed * airControl) + (transform.right * movementForce.x * playerSpeed));

            //sets and clamps new values
            float newx, newz;
            newx = Mathf.Clamp(transform.GetComponent<Rigidbody>().velocity.x, -AirSpeed, AirSpeed);
            newz = Mathf.Clamp(transform.GetComponent<Rigidbody>().velocity.z, -AirSpeed, AirSpeed);
            Vector3.MoveTowards(transform.GetComponent<Rigidbody>().velocity, new Vector3(newx, 0, newz), 30 * Time.deltaTime);
            //transform.GetComponent<Rigidbody>().AddForce(new Vector3(newx, transform.GetComponent<Rigidbody>().velocity.y, newz));

            //Airborne stopping code. If player is moving in X direction and user presses the key to move in -X, player will come to a stop, A-La Source.
            if (transform.InverseTransformPoint(transform.GetComponent<Rigidbody>().velocity).y / Mathf.Abs(transform.InverseTransformPoint(transform.GetComponent<Rigidbody>().velocity).y)
                == movementForce.y / Mathf.Abs(movementForce.y) && movementForce.y != 0)
            {
                //calculated through worldtolocalmatrix so the local z value can be modified, instead of the global z value.
                Vector3 tempVec = transform.worldToLocalMatrix * transform.GetComponent<Rigidbody>().velocity;
                tempVec.z /= 1.1f;
                transform.GetComponent<Rigidbody>().velocity = transform.localToWorldMatrix * tempVec;
            }

            //gotta impliment this for NSCM. Wouldn't feel complete without it.
            //backwards movement modifier. Makes sure if you hit -Y on controller while moving in +Y the player instantly stops moving in +Y
            //if (movementForce.y < -.1f && transform.InverseTransformPoint(transform.GetComponent<Rigidbody>().velocity).y < .01f)
            //{
            //    //calculated through worldtolocalmatrix so the local z value can be modified, instead of the global z value.
            //    Vector3 tempVec = transform.worldToLocalMatrix * transform.GetComponent<Rigidbody>().velocity;
            //    tempVec.z /= 1.1f;
            //    transform.GetComponent<Rigidbody>().velocity = transform.localToWorldMatrix * tempVec;
            //}

            //if (movementForce.y < -.1f && transform.InverseTransformPoint(transform.GetComponent<Rigidbody>().velocity).y < .01f)
            //{     
            //    //calculated through worldtolocalmatrix so the local z value can be modified, instead of the global z value.
            //    Vector3 tempVec = transform.worldToLocalMatrix * transform.GetComponent<Rigidbody>().velocity;
            //    tempVec.z /= 1.1f;
            //    transform.GetComponent<Rigidbody>().velocity = transform.localToWorldMatrix * tempVec;
            //}
        }
    }


    /*
     * two-stage check to see if the player is grounded
     */
    public bool isGrounded()
    {
        //creating and assigning locations for the raycast tests.
        float rad = transform.GetComponent<Collider>().bounds.extents.y;
        Vector3 modUp = new Vector3(rad / 2, 0, 0), modDown = new Vector3(-rad / 2, 0, 0), modLeft = new Vector3(0, 0, -rad / 2), modRight = new Vector3(0, 0, rad / 2);
        if (transform.GetComponent<Rigidbody>().velocity.y < -.1)
        {
            return false;
        }
        //below is to visualize the raws drawn for raycast test.
        if (displayDebugInfo)
        {
            UnityEngine.Debug.DrawRay(transform.localPosition, -transform.up, Color.green, groundedCheckdist);
            UnityEngine.Debug.DrawRay(transform.localPosition + modLeft, -transform.up, Color.green, groundedCheckdist);
            UnityEngine.Debug.DrawRay(transform.localPosition + modUp, -transform.up, Color.green, groundedCheckdist);
            UnityEngine.Debug.DrawRay(transform.localPosition + modDown, -transform.up, Color.green, groundedCheckdist);
            UnityEngine.Debug.DrawRay(transform.localPosition + modRight, -transform.up, Color.green, groundedCheckdist);
        }
        //checks if any of the player is close enough to the ground
        if (Physics.Raycast(transform.localPosition, -transform.up, groundedCheckdist) || Physics.Raycast(transform.localPosition + modLeft, -transform.up, groundedCheckdist) ||
            Physics.Raycast(transform.localPosition + modUp, -transform.up, groundedCheckdist) || Physics.Raycast(transform.localPosition + modDown, -transform.up, groundedCheckdist) ||
            Physics.Raycast(transform.localPosition + modRight, -transform.up, groundedCheckdist)) //Many tests ensures a result that feels good to the player.
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    /*
    * handles the camera's Y and the parent's X (therefore also handling the camera's X)
    */
    private void MoveCamera(Vector2 rotation)
    {
        //does playerobject rotation
        currentRotation.y += rotation.x * sensitivity;
        currentRotation.y = Mathf.Repeat(currentRotation.y, 360);
        transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);

        //manipulates the child camera to sync with the y value of the parent.
        cameraRot.x -= rotation.y * sensitivity;

        //clamps the y rotation of the camera from -maxYangle to maxYangle to prevent the camera inverting itself
        cameraRot.x = Mathf.Clamp(cameraRot.x, -maxYAngle, maxYAngle);

        cameraObject.transform.localRotation = Quaternion.Euler(cameraRot.x, 0, 0);
    }

    /*
    * adds jumpheight to player as an addforce, to simulate a jump.
    */
    private void Jump()
    {
        if (isGrounded())
        {
            transform.GetComponent<Rigidbody>().AddForce(0, jumpHeight * 20, 0);
        }
    }

    /*
    * switches the camera's localposition from FPPos to FPPos+TPPos.
    */
    private void SwitchCameraPos()
    {
        if (isTP)
        {
            print("running this");
            cameraObject.transform.localPosition = FPPos;
            isTP = !isTP;
        }
        else
        {
            cameraObject.transform.localPosition += TPPos;
            isTP = !isTP;
        }
    }


    private void Use()
    {
        print("okay, so this is working.");
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            float d = Vector3.Dot(direction, transform.forward);

            if (d >= .75)
            {
                Debug.Log("hey, we triggered the thing!");
                //play press sound
                return;
            }
        }
        //play fail sound
        return;
    }
}
