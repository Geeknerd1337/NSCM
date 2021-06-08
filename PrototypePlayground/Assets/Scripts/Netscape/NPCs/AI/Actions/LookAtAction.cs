using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/LookAt")]
public class LookAtAction : AIAction
{

    public float rotationSpeed;

    public override void Act(AIEntity controller)
    {
        MoveTowards(controller);
    }

    void MoveTowards(AIEntity controller)
    {
        RotateTowards(controller.Player, controller.transform);
    }

    private void RotateTowards(Transform target, Transform me)
    {
        Vector3 direction = (target.position - me.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        me.rotation = Quaternion.Slerp(me.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
