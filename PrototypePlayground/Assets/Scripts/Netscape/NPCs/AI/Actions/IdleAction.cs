using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Idle")]
public class IdleAction : AIAction
{
    
    public Vector2 idleTime;
    public float movementRange;
    public override void Act(AIEntity controller)
    {
        Idle(controller);
    }

    private void Idle(AIEntity controller)
    {
        // This was causing some errors that flooded the console.
        

        if(controller.Timers[0] > controller.Floats[0])
        {
            Vector3 initialPosition = controller.transform.position;
            initialPosition += controller.transform.forward * Random.Range(-movementRange, movementRange);
            initialPosition += controller.transform.right * Random.Range(-movementRange, movementRange);
            controller.Agent.destination = initialPosition;
            controller.Agent.isStopped = false;
            controller.Timers[0] = 0;
            controller.Floats[0] = Random.Range(idleTime.x, idleTime.y);


        }
        

        if (controller.Agent.remainingDistance <= controller.Agent.stoppingDistance && !controller.Agent.pathPending)
        {
            
        }
        
    }
}
