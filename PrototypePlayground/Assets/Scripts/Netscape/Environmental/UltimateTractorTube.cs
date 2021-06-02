using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class UltimateTractorTube : MonoBehaviour
{
    //The path creator
    private PathCreator path;
    //The thickness along the path used to detect collisions
    [SerializeField]
    private float pathThickness;
    //A boolean telling us if the player is travelling
    private bool isTravelling;
    //A float holding where along the path we are as a percentage
    private float pathTime;
    //A float holding a value that determines how quickly along the path we move
    [SerializeField]
    private float followSpeed;
    //A float representing a value that represents how smoothly we follow the path (values too high will cause some weirdness)
    [SerializeField]
    private float followQuality;
    //A vector3 representing the next physical point we are moving to along the path
    Vector3 targetPosition = Vector3.zero;
    //A float representing how much force to apply at the end of the path
    [SerializeField]
    private float endForce;
    private float travelTimeDelay;

    [Header("Audio")]
    [SerializeField]
    private AudioSource enterAndExit;
    [SerializeField]
    private AudioClip enter;
    [SerializeField]
    private AudioClip exit;
    [SerializeField]
    private AudioSource loop;


    [Header("Movement While Travelling")]
    [SerializeField]
    private AnimationCurve animatorCurve;
    [SerializeField]
    private AnimationCurve escapeCurve;
    [SerializeField]
    private float tubePlayerMovementSpeed;
    [SerializeField]
    private float tubePlayerExitForce;

    [Header("Player Stuff")]
    //Player transform reference
    [SerializeField]
    private Transform playerTransform;
    //Player Collider Reference
    [SerializeField]
    private Collider playerCollider;
    //A reference to the current version of the character controller. Designing this tube to be able to just provide the vector
    private CyberSpaceFirstPerson player;

    //A tester transform for shits and giggles
    [SerializeField]
    private Transform testingTransform;

    private Vector3 previousPosition;
    private Vector3 closestPoint;
    private int frameTimer;
   

    // Start is called before the first frame update
    void Start()
    {
        //Get the path
        path = GetComponent<PathCreator>();
        //Find the player
        player = FindObjectOfType<CyberSpaceFirstPerson>();
        //Save a reference to their transform
        playerTransform = player.transform;
        //Get their collider
        playerCollider = player.GetComponent<Collider>();
        //Previous Position
        previousPosition = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        closestPoint = GetClosestPointToTransform();

        Travel();
    }

    Vector3 GetClosestPointToTransform()
    {
        return path.path.GetClosestPointOnPath(playerTransform.position);
    }


     bool CheckIfColliderIsInTube()
    {
        Vector3 closest = closestPoint;
        //I'm experimenting here, but theoretically if we get the closest point on the collider to the closest point to the transform on 
        Vector3 point  = playerCollider.ClosestPoint(closest);
        float distance = Vector3.Distance(point, closest);
        if(distance < pathThickness)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void Travel()
    {
        //Basically, once we "collide", begin travelling
        if(CheckIfColliderIsInTube() && !isTravelling && travelTimeDelay <= 0)
        {
            isTravelling = true;
            pathTime = path.path.GetClosestTimeOnPath(playerTransform.position);
            targetPosition = path.path.GetPointAtTime(pathTime);
            enterAndExit.PlayOneShot(enter);
            loop.Play();
        }

        //This is basically to prevent people from being sucked right back into the tube if they exit it
        if(travelTimeDelay > 0)
        {
            travelTimeDelay -= Time.deltaTime;
        }


        //Move the player if they are travelling!
        if (isTravelling)
        {
            
            //Get the distance of the players transform to the target position
            float distance = Vector3.Distance(playerTransform.position, closestPoint);
            //This basically gives us a function for how 'close' we are to the center of the tube when travelling. 
            float amt = 1 - Mathf.Clamp01(distance / pathThickness);


            //Get the direction to the next 'point'
            Vector3 dir = (targetPosition - player.transform.position);
            //Storing as another vector3 incase we decide to manipulate it later
            Vector3 totalDir = dir;
            if (Vector3.Distance(targetPosition, player.transform.position) < 1f)
            {
                targetPosition = path.path.GetPointAtTime(pathTime);
                //This is going to be multiplied by the curve because we want the player not to be moving unless they are pretty much dead center on the curve
                //This evalualtes the curve so that we move slower the further away from the center of the tube we are.
                pathTime += (1 / followQuality) * animatorCurve.Evaluate(amt);


            }
            float resistence = 1f;
            Vector3 tubeMovement = Vector3.zero;
            if(tubeMovement.magnitude > 0.1f)
            {
                resistence = escapeCurve.Evaluate(amt);
            }


            //Effect the player's movement vector
            player.AddDirVector = (totalDir.normalized * followSpeed * resistence) + tubeMovement;

            print(amt);

            //Basically if we exit the tube, stop travelling
            //Commenting out for now because it doesn't feel very good
            /*if (!CheckIfColliderIsInTube())
            {
                Vector3 playerMovementDirection = player.AddDirVector;
                isTravelling = false;
                travelTimeDelay = 1f;
                pathTime = 0;
                player.leftOverVelocity = playerMovementDirection * tubePlayerExitForce;
            }*/

            //Replacing with a system where you press space to hop out
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isTravelling = false;
                travelTimeDelay = 2f;
                pathTime = 0;
                player.leftOverVelocity = player.PlayerCamera.transform.forward * tubePlayerExitForce;
                enterAndExit.PlayOneShot(exit);
                loop.Stop();
            }

            if(pathTime >= 1)
            {
                isTravelling = false;
                travelTimeDelay = 1f;
                player.leftOverVelocity = dir * endForce;
                pathTime = 0;
                enterAndExit.PlayOneShot(exit);
                loop.Stop();
            }
            previousPosition = player.transform.position;
        }

        

      


    }

    //Since I'm a crazy asshole, we need to stick a big ole TODO: on here because I absolutely should not be handling the movement towards the outside of the tube 
    //In this class, so lord forgive me.
    Vector3 GetPlayerTubeMovement()
    {
        Transform playerCamera = player.PlayerCamera.transform;

        //Get the vertical and horizontal input from the players keys
        Vector2 playerInput;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        //Now, for the time being, construct a vector 3 using this movement.
        Vector3 movement = (playerCamera.transform.right * playerInput.x) + (playerCamera.transform.forward * playerInput.y);
        movement = movement.normalized * tubePlayerMovementSpeed;

        return movement;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(testingTransform.position, pathThickness);
    }
}
