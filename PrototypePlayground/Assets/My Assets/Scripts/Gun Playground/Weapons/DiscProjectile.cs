using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;

    private bool targetFound;
    private Transform target;
    private Vector3 midPoint;

    private float angle;

    [Header("Stuff for a spherecast needed for homing in on enemies")]
    public float searchRange;
    public float searchSphereWidth;
    public LayerMask searchMask;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetFound)
        {
            MoveForward();
            LookForTarget();
        }
        else
        {

        }
    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }


    void LookForTarget()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, searchSphereWidth, transform.forward, out hit, searchRange, searchMask))
        {
            EntityLimb e = hit.collider.GetComponent<EntityLimb>();

            if(e != null)
            {
                target = e.transform;
                targetFound = true;

                Vector3 dir = target.position - transform.position;
                dir = dir.normalized;
                midPoint = transform.position + dir * Vector3.Distance(transform.position, target.position);
                Vector3 up = Vector3.up;
                

            }
        }
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 P2)
    {
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        return p + (2 * u * t * p1) + (tt * P2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject g = collision.gameObject;
        EntityLimb e = g.GetComponent<EntityLimb>();
        if (e != null)
        {
            e.DamageEnemy(damage, transform.forward);
            transform.SetParent(e.transform);
            this.enabled = false;
        }
        else
        {
            Vector3 reflectedAngle = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(reflectedAngle);
        }
    }
}
