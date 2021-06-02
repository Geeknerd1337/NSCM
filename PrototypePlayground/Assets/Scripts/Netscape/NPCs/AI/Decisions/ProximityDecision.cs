using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Proximity Check")]
public class ProximityDecision : AIDecision
{

    public float radius;
    public override bool Decide(AIEntity controller)
    {
        bool targetVisible = Search(controller);
        return targetVisible;
    }

    private bool Search(AIEntity controller)
    {

        if(Vector3.Distance(controller.transform.position,controller.Player.position) < radius)
        {
            return true;
        }
        return false;

    }
}
