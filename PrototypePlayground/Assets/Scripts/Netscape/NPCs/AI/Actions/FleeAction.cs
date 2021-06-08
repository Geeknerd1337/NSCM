using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Flee")]
public class FleeAction : AIAction
{

    public float fleeRadius;
    public override void Act(AIEntity controller)
    {
        Flee(controller);
        
    }

    private void Flee(AIEntity controller)
    {
        if (controller.fleePoint == Vector3.zero)
        {
            controller.Agent.SetDestination(controller.GetFleePoint(fleeRadius));
        }
    }
}
