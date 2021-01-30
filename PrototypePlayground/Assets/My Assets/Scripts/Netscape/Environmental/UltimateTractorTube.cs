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

    }

    // Update is called once per frame
    void Update()
    {
        Travel();
    }

    Vector3 GetClosestPointToTransform()
    {
        return path.path.GetClosestPointOnPath(playerTransform.position);
    }


     bool CheckIfColliderIsInTube()
    {
        //I'm experimenting here, but theoretically if we get the closest point on the collider to the closest point to the transform on 
        Vector3 point  = playerCollider.ClosestPoint(GetClosestPointToTransform());
        float distance = Vector3.Distance(point, GetClosestPointToTransform());
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
            Debug.Log(pathTime);
        }

        //This is basically to prevent people from being sucked right back into the tube if they exit it
        if(travelTimeDelay > 0)
        {
            travelTimeDelay -= Time.deltaTime;
        }


        //Move the player if they are travelling!
        if (isTravelling)
        {
            //Get the direction to the next 'point'
            Vector3 dir = (targetPosition - player.transform.position);
            //Storing as another vector3 incase we decide to manipulate it later
            Vector3 totalDir = dir;
            if (Vector3.Distance(targetPosition, player.transform.position) < 1f)
            {
                targetPosition = path.path.GetPointAtTime(pathTime);
                pathTime += 1 / followQuality;

            }
            player.AddDirVector = totalDir.normalized * followSpeed;

            if(pathTime >= 1)
            {
                isTravelling = false;
                travelTimeDelay = 1f;
                player.leftOverVelocity = dir * endForce;
                pathTime = 0;
            }

        }

      


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(testingTransform.position, pathThickness);
    }
}
