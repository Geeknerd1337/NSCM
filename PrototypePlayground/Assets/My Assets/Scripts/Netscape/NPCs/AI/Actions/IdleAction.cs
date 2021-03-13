using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle")]
public class IdleAction : AIAction
{
    private float timer;
    public Vector2 idleTime;
    private float idleTimeActual;
    public float movementRange;
    public override void Act(AIEntity controller)
    {
        Idle(controller);
    }

    private void Idle(AIEntity controller)
    {
        timer += Time.deltaTime;
        if(timer > idleTimeActual)
        {
            Vector3 initialPosition = controller.transform.position;
            initialPosition += controller.transform.forward * Random.Range(-movementRange, movementRange);
            initialPosition += controller.transform.right * Random.Range(-movementRange, movementRange);
            controller.Agent.destination = initialPosition;
            controller.Agent.isStopped = false;
            timer = 0;
            idleTimeActual = Random.Range(idleTime.x, idleTime.y);


        }
        

        if (controller.Agent.remainingDistance <= controller.Agent.stoppingDistance && !controller.Agent.pathPending)
        {
            
        }
    }
}
