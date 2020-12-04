using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/Decisions/Desination Reached")]
public class DestinationDecision : AIDecision
{
    public override bool Decide(AIEntity controller)
    {
        return DestinationReached(controller);
    }

    private bool DestinationReached(AIEntity controller)
    {
        
        if(controller.Agent.remainingDistance < 0.2f)
        {
            if (controller.Agent.hasPath)
            {

                return true;
            }
        }
        else
        {
            return false;
        }
        return false;

    }
}
