using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Sphere Search")]
public class GenericSearchDecision : AIDecision
{
    public LayerMask lm;


    public override bool Decide(AIEntity controller)
    {
        bool targetVisible = Search(controller);
        return targetVisible;
    }

    private bool Search(AIEntity controller)
    {
        RaycastHit hit;
        Debug.DrawRay(controller.Eyes.position, (controller.Player.position- controller.Eyes.position) * controller.EnemyStats.searchRadius, Color.green);
        if (Physics.SphereCast(controller.Eyes.position, 1f, (controller.Player.position - controller.Eyes.position).normalized, out hit, controller.EnemyStats.searchRadius, lm))
        {
            //Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Player"))
            {
                controller.CurrentTarget = hit.transform;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
