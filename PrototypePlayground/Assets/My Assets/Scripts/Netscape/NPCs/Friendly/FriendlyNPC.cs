using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendlyNPC : MonoBehaviour
{
    #region Private Members
    private NavMeshAgent agent;
    private Animator friendlyAnimator;
    #endregion

    [SerializeField]
    private Transform target;

    [SerializeField]
    public bool runningCircle;

    [Header("Running In Circle")]
    public List<Transform> circlePoints;
    [SerializeField]
    private int circleIndex;
    public Animator a;
    public AudioSource sound;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    private float jumpTimer;

    public Transform armature;
    public float rotSpd;
    private float myY;


    // Start is called before the first frame update
    void Start()
    {
        //Get The Agent;
        agent = GetComponent<NavMeshAgent>();
        //Get the Animator
        friendlyAnimator = GetComponent<Animator>();
        a = GetComponent<Animator>();
        //GoToCurrentTarget();

        jumpTimer = Random.Range(1f, 3f);
        myY = armature.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAI();
    }

    private void LateUpdate()
    {
        if (runningCircle)
        {
            RotateToTargetSmooth(circlePoints[circleIndex], rotSpd);
        }
    }
    void UpdateAI()
    {

        //Basically check if the agent is moving
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            friendlyAnimator.SetBool("IsWalking", false);
        }
        else
        {
            friendlyAnimator.SetBool("IsWalking", true);
        }


        if (runningCircle)
        {
            TravelCircle();
            friendlyAnimator.SetBool("IsWalking", true);
        }
    }

    void GoToCurrentTarget()
    {
        agent.SetDestination(target.position);
    }


    void TravelCircle()
    {
        Transform currPoint = circlePoints[circleIndex];
        if (agent.remainingDistance < 0.3f)
        {
            agent.SetDestination(currPoint.position);
            circleIndex++;
            if (circleIndex >= circlePoints.Count - 1)
            {
                circleIndex = 0;
            }
          
        }

        jumpTimer -= Time.deltaTime;
        if(jumpTimer <= 0)
        {
            //sound.PlayOneShot(jumpSound);
            //a.Play("Armature|Jump");
            jumpTimer = Random.Range(1f, 3f);
           // Vector3 t = transform.position;
        }

        if (a.GetCurrentAnimatorStateInfo(0).IsName("Armature|Jump"))
        {
            agent.speed = 10f;
        }
        else
        {
            agent.speed = 5f;
            sound.PlayOneShot(jumpSound);
            a.Play("Armature|Jump");
        }
    }

    void RotateToTarget(Transform t)
    {
        Vector3 dir = (t.position - armature.position);
        Quaternion q = Quaternion.LookRotation(dir.normalized);
        Vector3 euler = q.eulerAngles;
        armature.transform.eulerAngles = new Vector3(-90f, euler.y, 0);
    }

    void RotateToTargetSmooth(Transform t,float f)
    {
        Vector3 dir = (t.position - armature.position);
        Quaternion q = Quaternion.LookRotation(dir.normalized);
        Vector3 euler = q.eulerAngles;
        myY = Mathf.LerpAngle(myY, euler.y, f * Time.deltaTime);
        armature.transform.eulerAngles = new Vector3(-90f, myY, 0);

    }
}
