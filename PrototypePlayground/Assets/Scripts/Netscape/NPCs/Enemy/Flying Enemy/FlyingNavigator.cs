using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingNavigator : MonoBehaviour
{

    public FlyingNodeManager Manager;
    public CyberSpaceFirstPerson fps;
    public List<FlyingNode> MyPath;

    public float MaxSpeed;
    public float Speed;
    public float Acceleration;
    public float StoppingAcceleration;
    public float StoppingDistance;
    public float TurningSpeed;
    public float TurningAcceleration;
    public float MaxTurningSpeed;
    public Vector3 Target;
    private Vector3 TargetDirection;

    public List<Ray> AvoidanceRays = new List<Ray>();

    public void GenerateRay(int samples = 1)
    {
        float x, y, z, theta;
        float radius = 1f;

        float phi = Mathf.PI * (3f - Mathf.Sqrt(5f));

        for(int i = 0; i < samples; i++)
        {
            y = 1 - ((float)i / (samples - 1)) * 2f;
            radius = Mathf.Sqrt(1 - y * y);
            theta = phi * i;

            x = Mathf.Cos(theta) * radius;
            z = Mathf.Sin(theta) * radius;

            Ray r = new Ray(transform.position, new Vector3(x, y, z));
            AvoidanceRays.Add(r);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fps = FindObjectOfType<CyberSpaceFirstPerson>();
        Manager = FindObjectOfType<FlyingNodeManager>();
        Target = transform.position;
        GenerateRay(64);
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != Vector3.zero)
        {
            MoveToTarget();
        }
        
    }

    public void MoveToTarget()
    {
        TickSpeed();
        TickRotation();

        

        transform.position += Time.deltaTime * Speed * TargetDirection;
    }

    /// <summary>
    /// This function works similarly to tick speed, but for the 'direction' we are moving
    /// </summary>
    void TickRotation()
    {
        float dist = Vector3.Distance(transform.position, Target);
        Vector3 dir = (Target - transform.position).normalized;
        float dot = Vector3.Dot(dir, TargetDirection);

        if(dot < 0.95f && dist > StoppingDistance)
        {
            TurningSpeed = Mathf.Clamp(TurningSpeed + Time.deltaTime * TurningAcceleration, 0, MaxTurningSpeed);
            TargetDirection = Vector3.MoveTowards(TargetDirection, dir, TurningSpeed * Time.deltaTime);
        }

        if(dot >= 0.95f || dist <= StoppingDistance)
        {
            TurningSpeed = Mathf.Clamp(TurningSpeed - Time.deltaTime * TurningAcceleration, 0, MaxTurningSpeed);
        }
    }

    /// <summary>
    /// This function will speed us up or slow us down based on our stopping distance and our distance to the target
    /// </summary>
    void TickSpeed()
    {
        if (Vector3.Distance(transform.position, Target) > StoppingDistance)
        {
            Speed = Mathf.Clamp(Speed + Acceleration * Time.deltaTime, 0, MaxSpeed);
        }
        else
        {
            Speed = Mathf.Clamp(Speed - StoppingAcceleration * Time.deltaTime, 0, MaxSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        if (MyPath != null && MyPath.Count >= 2)
        {
            Gizmos.color = (Color.blue);
            for (int i = 1; i < MyPath.Count; i++)
            {

                Gizmos.DrawLine(MyPath[i].transform.position + Vector3.up * 0.05f, MyPath[i - 1].transform.position + Vector3.up * 0.05f);
                Gizmos.DrawWireSphere(MyPath[i].transform.position, 1f);
                Gizmos.DrawWireSphere(MyPath[i - 1].transform.position, 1f);
            }
            Gizmos.color = (Color.white);
        }

        Gizmos.DrawLine(transform.position, transform.position + TargetDirection * Speed);


        for(int i = 0; i < AvoidanceRays.Count; i++)
        {
            Gizmos.DrawLine(transform.position, transform.position +  AvoidanceRays[i].direction * 1f);
        }
    }

    
}
