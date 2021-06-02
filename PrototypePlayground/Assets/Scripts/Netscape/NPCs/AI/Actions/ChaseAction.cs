using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : AIAction
{

    public bool circleStrafe;
    public float strafeSpeed;
    public Vector2 strafeTime;
    public override void Act(AIEntity controller)
    {
        Chase(controller);
    }

    private void Chase(AIEntity controller)
    {
        
        if (!circleStrafe)
        {
            controller.Agent.destination = controller.Player.transform.position + (controller.transform.position - controller.Player.position).normalized * controller.StoppingDistance;
        }
        else
        {
            if (controller.StrafeTimer == 0)
            {
                controller.StrafeTimer = Random.Range(strafeTime.x, strafeTime.y);
            }
            else
            {
                controller.StrafeTimer -= Time.deltaTime;
                if (controller.StrafeTimer <= 0)
                {
                    controller.StrafeMod *= -1;
                    
                    controller.StrafeTimer = 0;
                }
            }
            if(Vector3.Distance(controller.Player.position,controller.transform.position) < controller.StoppingDistance * 1.5f)
            {
                float strafe = strafeSpeed * (float)controller.StrafeMod;
                Vector3 newDir = Quaternion.Euler(0, strafe, 0) * (controller.transform.position - controller.Player.position).normalized;
                controller.Agent.destination = controller.Player.transform.position + newDir * controller.StoppingDistance;
                Debug.DrawRay(controller.Agent.destination, Vector3.up * 10f);
            }
            else
            {
                controller.Agent.destination = controller.Player.transform.position + (controller.transform.position - controller.Player.position).normalized * controller.StoppingDistance;
            }
        }
    }
}
