using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{
    public ParticleSystem p;
    public LayerMask lm;
    public float range;
    public Transform shockPoint;
    public GameObject laser;
    public Transform effectPoint;
    public float damage;
    private AIEntity ai;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<AIEntity>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticle()
    {
        p.Play();
        sound.Play();
    }

    public void Attack()
    {
        RaycastHit hit;

        Vector3 dir = (ai.Player.position - shockPoint.position);

        if(Physics.Raycast(shockPoint.position,dir,out hit, range, lm))
        {
            GameObject g = Instantiate(laser);
            GrapplingLineRenderer gr = g.GetComponentInChildren<GrapplingLineRenderer>();
            gr.origin.position = effectPoint.position;
            gr.desination.position = hit.point;
            if(hit.collider.tag == "Player")
            {
                PlayerStats p = hit.collider.GetComponent<PlayerStats>();
                p.DamagePlayer(damage, transform.position);
            }

        }
    }
}
