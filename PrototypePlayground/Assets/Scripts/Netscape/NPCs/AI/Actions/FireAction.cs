using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/FireAttack")]
public class FireAction : AIAction
{
    public AIState ReturnState;
    public float TimeToFire;
    public float TimeToReturn;

    [Range(0,1f)]
    public float ChanceToBurst;
    public float TimeBetweenShots;
    public int NumShotsInBurst;



    public override void Act(AIEntity controller)
    {
        Fire(controller);
        
    }




    
    private void Fire(AIEntity controller)
    {
        if (controller.stateTimer > TimeToFire && controller.FireTimer != 0)
        {
            float chance = Random.Range(0, 1f);

            if (chance > ChanceToBurst)
            {
                controller.FireTimer = 0f;
                controller.Weapon.FireWeapon(1,0f);
            }
            else
            {
                controller.FireTimer = 0f;
                //System.Action<AIEntity> fireWeapon = (AIEntity c) => { c.Weapon.FireWeapon(); };
                //controller.StartCoroutine(controller.RunFunctionXTimes(TimeBetweenShots, NumShotsInBurst, fireWeapon));
                controller.Weapon.FireWeapon(NumShotsInBurst, TimeBetweenShots);

            }
        }

        //This code returns us to our desired state after firing our weapon
        if(controller.stateTimer > TimeToFire + TimeToReturn)
        {
            controller.TransitionToState(ReturnState);
        }

        if (controller.Agent.remainingDistance > 1f)
        {
            controller.Agent.destination = controller.transform.position + controller.transform.forward * 0.95f;
        }
    }
}
