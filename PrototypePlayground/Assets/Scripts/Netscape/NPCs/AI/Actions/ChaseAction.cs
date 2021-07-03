using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : AIAction
{

    public bool circleStrafe;
    public bool strafe;
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
            Vector3 playerPosition = controller.Player.transform.position;
            Vector3 dirFromPlayerToThis = (controller.transform.position - playerPosition).normalized;
            Vector3 dirFromThisToPlayer = (playerPosition - controller.transform.position).normalized;
            Vector3 dirPerpFromThisToPlayer = Vector3.Cross(dirFromPlayerToThis, Vector3.up);

            Vector3 stopPosition = (dirFromPlayerToThis * (controller.StoppingDistance * 0.5f));
            float perlin = Mathf.Sin(controller.timer * strafeSpeed);//(Mathf.PerlinNoise(controller.timer * 0.75f, 0) * 2f) - 1;

            Vector3 strafePosition = dirPerpFromThisToPlayer * perlin * 5f;

            if (strafe)
            {
                controller.Agent.destination = (playerPosition) + strafePosition + stopPosition;
                Debug.DrawRay(controller.Agent.destination, Vector3.up * 5f, Color.blue);
            }
            else
            {
                controller.Agent.destination = controller.Player.transform.position + (controller.transform.position - controller.Player.position).normalized * controller.StoppingDistance;
            }

            Debug.DrawRay(controller.Agent.destination, Vector3.up * 10f, Color.blue);

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
                //Debug.DrawRay(controller.Agent.destination, Vector3.up * 10f);
            }
            else
            {
                Vector3 playerPosition = controller.Player.transform.position;
                Vector3 dirFromPlayerToThis = (controller.transform.position - playerPosition).normalized;
                Vector3 dirFromThisToPlayer = (playerPosition - controller.transform.position).normalized;
                Vector3 dirPerpFromThisToPlayer = Vector3.Cross(dirFromPlayerToThis, Vector3.up);

                Vector3 stopPosition = dirFromPlayerToThis * controller.StoppingDistance;
                controller.Agent.destination = (playerPosition) + dirPerpFromThisToPlayer * 5f;

                Debug.DrawRay((playerPosition), Vector3.up * 10f,Color.blue);
            }
        }
    }
}
