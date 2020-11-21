using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Fire Weapon")]
public class FireDecision : AIDecision
{
    public override bool Decide(AIEntity controller)
    {
        bool targetVisible = Fire(controller);
        if (controller.FireTimer == 0f)
        {
            Vector2 v = controller.EnemyStats.fireCooldown;
            controller.FireTimer = Random.Range(v.x, v.y);
        }
        else
        {
            controller.FireTimer -= Time.deltaTime;
            if(controller.FireTimer <= 0)
            {
                controller.Weapon.FireWeapon();
                controller.FireTimer = 0f;
            }
        }
        return targetVisible;
        
    }

    private bool Fire(AIEntity controller)
    {

        return true;
    }
}
