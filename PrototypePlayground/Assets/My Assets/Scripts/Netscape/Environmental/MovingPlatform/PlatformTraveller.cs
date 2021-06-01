using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTraveller : MonoBehaviour
{
    /// <summary>
    /// A Vector holding the objects previous position in world space
    /// </summary>
    private Vector3 previousPosition;
    /// <summary>
    /// A vector representing our movemenet as a direction and magnitude
    /// </summary>
    public Vector3 dirMag;

    public Vector3 moveDir;

    /// <summary>
    /// A calculated vector holding the 'velocity' of the object. Used for giving the player velocity when they leave the platform
    /// </summary>
    private Vector3 velocity;


    /// <summary>
    /// A reference to our player
    /// </summary>
    private CyberSpaceFirstPerson player;

    /// <summary>
    /// The transform of our parent. Since this goes on a trigger, we need to figure out who our actual parent is for movement and tracking purposes.
    /// </summary>
    public Transform parentTransform;

    /// <summary>
    /// A variable denoting the speed the object moves if we move with programatic movement instead of using an animator.
    /// </summary>
    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        //Initialize the previous position
        previousPosition = transform.position;
        //Dirty way of getting a reference to the player object.
        
        player = FindObjectOfType<CyberSpaceFirstPerson>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //This code here just stored our 'velocity' into a vec3
        velocity = (transform.position - previousPosition)/Time.fixedDeltaTime;
        previousPosition = transform.position;

        //I couldn't really tell you why, but this has to be here. Even if the speed is zero for whatever, if we want this to work with animators this needs to be here
        dirMag = (transform.up + transform.forward) * Time.fixedDeltaTime;
        parentTransform.position += moveDir * speed * Time.fixedDeltaTime;
        Physics.SyncTransforms();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Basically, what we're doing here is because the way the player rotates horizontally, we have to remove our current rotation to make sure the player rotation stays consistent
        //Between local and world space
        if(other.tag == "Player")
        {
         
            player.mLook.xAdjust = -transform.eulerAngles.y;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //If we're in the collider, set our parent to this platform and add our direction magnitude to the players direction magnitude
        if (other.tag == "Player")
        {
            player.transform.SetParent(parentTransform);
            player.platformDirMag = dirMag/Time.fixedDeltaTime;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Mainly just resets the player and adds our left over velocity if we jump, also correct for rotation just like the enter
        if (other.tag == "Player")
        {
            player.platformDirMag = Vector3.zero;
            player.transform.SetParent(null);
            //This line of code is just for pausing the mouselook calculation for one frame so the rotation can be set
            player.outsideRot = true;
            player.mLook.xAdjust = transform.eulerAngles.y;
            //Give the player our velocity if they jump
            player.leftOverVelocity = velocity;
            
        }

    }
        
}
