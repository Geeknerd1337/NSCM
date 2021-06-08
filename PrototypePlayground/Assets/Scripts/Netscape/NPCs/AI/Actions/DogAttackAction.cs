using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Attack/Dog")]
public class DogAttackAction : AIAction
{
    public override void Act(AIEntity controller)
    {
        Attack(controller);
    }

    private void Attack(AIEntity controller)
    {

    }
}
