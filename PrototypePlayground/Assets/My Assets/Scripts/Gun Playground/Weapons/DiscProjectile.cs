using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;

    private bool targetFound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
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
        if(g.tag == "Enemy")
        {

        }
        else
        {
            Vector3 reflectedAngle = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.rotation = Quaternion.LookRotation(reflectedAngle);
        }
    }
}
