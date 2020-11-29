using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : AIAction
{
    public override void Act(AIEntity controller)
    {
        Patrol(controller);
    }

    private void Patrol(AIEntity controller)
    {
        controller.Agent.destination = controller.AIWaypoints[controller.nextWaypoint].position;
        controller.Agent.isStopped = false;

        if(controller.Agent.remainingDistance <= controller.Agent.stoppingDistance && !controller.Agent.pathPending)
        {
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.AIWaypoints.Count;
        }
    }
}
