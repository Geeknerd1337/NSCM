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

    // Start is called before the first frame update
    void Start()
    {
        //Get The Agent;
        agent = GetComponent<NavMeshAgent>();
        //Get the Animator
        friendlyAnimator = GetComponent<Animator>();

        GoToCurrentTarget();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAI();
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
    }

    void GoToCurrentTarget()
    {
        agent.SetDestination(target.position);
    }
}
