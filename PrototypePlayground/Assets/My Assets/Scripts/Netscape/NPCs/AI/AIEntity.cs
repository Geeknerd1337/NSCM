using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEntity : MonoBehaviour
{

    #region Private enemy info
    [SerializeField]
    private EnemyStats enemyStats;
    [SerializeField]
    private Transform eyes;
    private Transform chaseTarget;
    private Transform player;
    private AIWeapon weapon;
    #endregion

    [Header("Enemy Information")]
    public AIState currentState;
    public AIState remainState;
    public EnemyStats EnemyStats { get { return enemyStats; } }
    public Transform Eyes { get { return eyes; } }
    public Transform ChaseTarget { get { return chaseTarget; }
                                   set { chaseTarget = value; }
    }
    public Transform Player { get { return player; } }
    public AIWeapon Weapon { get { return weapon; } }
   

    [Header("Waypoints")]
    [SerializeField]
    private List<Transform> waypoints;
    public List<Transform> AIWaypoints
    {
        get { return waypoints; }
        set { waypoints = value; }
    }
    public int nextWaypoint;

    [Header("Action Variables")]
    private float fireTimer = 0f;
    public float FireTimer { get { return fireTimer; } set { fireTimer = value; } }
    private float strafeTimer = 0f;
    public float StrafeTimer { get { return strafeTimer; } set { strafeTimer = value; } }
    [SerializeField]
    private int strafeMod = 1;
    public int StrafeMod { get { return strafeMod; } set { strafeMod = value; } }
    private float stoppingDistance;
    public float StoppingDistance { get { return stoppingDistance; } set { stoppingDistance = value; } }

    #region Private members
    private NavMeshAgent navMeshAgent;
    public NavMeshAgent Agent
    {
        get { return navMeshAgent; }
    }
    private bool aiActive;
    #endregion

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetUpAI(true);
    }

    private void Update()
    {
        RunAI();
    }

    private void RunAI()
    {
        if (!aiActive)
        {
            return;
        }
        else
        {
            currentState.UpdateState(this);
            
        }
    }

    public void SetUpAI(bool activateAI)
    {
        aiActive = activateAI;
        //Cache a reference to the player (TODO: Move to level manager singleton for performance)
        player = FindObjectOfType<CyberSpaceFirstPerson>().transform;
        //Get the weapon if one exists for the enemy
        weapon = GetComponent<AIWeapon>();
        if (weapon == null)
        {
            weapon = GetComponentInChildren<AIWeapon>();
        }
        //Set the strafe mod to a random value
        StrafeMod = Random.Range(-1, 1);
        while(StrafeMod == 0)
        {
            StrafeMod = Random.Range(-1, 1);
        }
        //Set the stopping distance for the enemy
        StoppingDistance = Random.Range(enemyStats.stoppingDistance.x, enemyStats.stoppingDistance.y);
        

        if (aiActive)
        {
            navMeshAgent.enabled = true;
            navMeshAgent.speed = enemyStats.moveSpeed;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }


    private void OnDrawGizmos()
    {
        if(currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }

    public void TransitionToState(AIState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
