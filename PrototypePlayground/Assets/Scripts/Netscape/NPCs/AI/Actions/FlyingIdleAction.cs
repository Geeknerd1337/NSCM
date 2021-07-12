using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/FlyingIdle")]
public class FlyingIdleAction : AIAction
{
    

    public Vector2 idleTime;

    public float movementRange;
    public LayerMask lm;


    public override void Act(AIEntity controller)
    {
        Idle(controller);
    }

    private void Idle(AIEntity controller)
    {
        
        if (controller.Timers[0] > controller.Floats[0])
        {

           Vector3 dir = Random.insideUnitSphere.normalized;
           RaycastHit hit;
            

            
            Vector3 initialPosition = Vector3.zero;
            int index = 0;
            while (initialPosition == Vector3.zero)
            {
                bool didHit = Physics.Raycast(controller.transform.position, dir, out hit, movementRange);
                if (!didHit)
                {
                    initialPosition = controller.transform.position + dir * Random.Range(movementRange / 2f, movementRange);
                }
                index++;
                if(index > 10)
                {
                    break;
                }
            }

            if (initialPosition != Vector3.zero)
            {
                controller.FlyingAgent.Target = initialPosition;
            }

            controller.Timers[0] = 0;
            controller.Floats[0] = Random.Range(idleTime.x, idleTime.y);


        }




    }
}
