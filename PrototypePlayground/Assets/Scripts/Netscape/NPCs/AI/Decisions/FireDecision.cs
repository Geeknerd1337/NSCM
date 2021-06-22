using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Fire Weapon")]
public class FireDecision : AIDecision
{
    public override bool Decide(AIEntity controller)
    {
        if (controller.FireTimer == 0f)
        {
            Vector2 v = controller.EnemyStats.fireCooldown;
            controller.FireTimer = Random.Range(v.x, v.y);
            return false;
        }
        else
        {
            controller.FireTimer -= Time.deltaTime;
            if(controller.FireTimer <= 0)
            {
                
                
                return true;
            }
        }
        return false;

        
    }

    private bool Fire(AIEntity controller)
    {

        return true;
    }
}
