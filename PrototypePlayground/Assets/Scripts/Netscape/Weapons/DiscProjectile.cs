﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;
    public float pointHeight;

    private bool targetFound;
    private Transform target;
    private Vector3 midPoint;
    [SerializeField]
    private Transform midPointObject;
    private Vector3 startPoint;
    public Transform disc;

    private float angle;

    [Header("SphereCast Data")]
    public float searchRange;
    public float searchSphereWidth;
    public LayerMask searchMask;

    //BezierMovement Test
    private float bezierAmt;
    [SerializeField]
    private float homingDelay;

    public float life;
    public int bounces;
    [SerializeField]
    private int bouncesMax;


    //Rotational Speed Test
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float forwardRotationSpeed;
    [SerializeField]
    private float maxRotationSpeed;
    [SerializeField]
    private float rotationSpeedAccel;

    private bool canMove;

    public ParticleSystem partSys;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0, 360f);
        bezierAmt = 0;
        forwardRotationSpeed *= Random.Range(-1f, 1f);
        rotationSpeed = 0;
        canMove = true;
        bounces = bouncesMax;
    }

    // Update is called once per frame
    void Update()
    {
        homingDelay -= Time.deltaTime;
        if (life > 0 && canMove)
        {
            if (!targetFound)
            {
                MoveForward();
                if (bounces < bouncesMax)
                {
                    LookForTargetOverlap();
                }
            }
            else
            {
                RotateTowardsTarget();
                //MoveBezeier();

            }
        }

        life -= Time.deltaTime;
        if(life <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        //disc.Rotate(midPointObject.transform.up, Time.deltaTime * forwardRotationSpeed);

        
    }

    void MoveBezeier()
    {
        bezierAmt += Time.deltaTime;
        bezierAmt = Mathf.Clamp01(bezierAmt);
        transform.position = CalculateQuadraticBezierPoint(bezierAmt, startPoint, midPoint, target.transform.position);
    }

    void RotateTowardsTarget()
    {
        
        if (homingDelay <= 0)
        {
            if (target != null)
            {
                rotationSpeed += rotationSpeedAccel * Time.deltaTime;
                rotationSpeed = Mathf.Clamp(rotationSpeed, 0, maxRotationSpeed);
                Vector3 dir = (target.position - offset) - transform.position;
                dir = dir.normalized;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            }
        }
        MoveForward();

    }


    void LookForTarget()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, searchSphereWidth, transform.forward, out hit, searchRange, searchMask))
        {
            EntityLimb e = hit.collider.GetComponent<EntityLimb>();

            if(e != null)
            {
                if (!e.EntityDead)
                {
                    target = e.transform;
                    targetFound = true;
                }


            }
        }
    }

    void LookForTargetOverlap()
    {
        Collider[] c = Physics.OverlapSphere(transform.position, searchSphereWidth,searchMask);
        foreach(Collider collider in c)
        {
            EntityLimb e =collider.GetComponent<EntityLimb>();

            if (e != null)
            {
                Debug.Log(e.EntityDead);
                if (!e.EntityDead)
                {
                    target = e.transform;
                    offset = e.transform.position - collider.bounds.center;
                    targetFound = true;
                }
                


            }
        }
    }

    void Die()
    {
        partSys.Play();
        partSys.transform.SetParent(null);
        Destroy(partSys.gameObject, 3f);
    }

    void MoveMidPoint()
    {
        Vector3 dir = (target.position + offset) - transform.position;
        dir = dir.normalized;
        midPoint = transform.position + dir * Vector3.Distance(transform.position, target.position) / 2f;

        midPointObject.position = midPoint;
        midPointObject.rotation = Quaternion.LookRotation(dir);
        midPointObject.Rotate(dir, angle);
        midPointObject.position += midPointObject.up * pointHeight;
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
            GetComponent<Collider>().enabled = false;
            canMove = false;
        }
        else
        {
            Vector3 reflectedAngle = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(reflectedAngle);
            bounces--;
            if(bounces <= 0)
            {
                Die();
                Destroy(gameObject);
            }
        }
    }

}
