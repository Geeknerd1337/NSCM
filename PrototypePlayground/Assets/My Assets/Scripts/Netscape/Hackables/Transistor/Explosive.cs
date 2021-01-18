using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    private AudioSource sound;

    public float radius;
    public float damage;
    public float explosiveForce;
    public float playerExplosiveForce;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        AreaDamageEnemies(transform.position, radius, damage);
        sound.Play();
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            EntityHealth enemy = col.GetComponent<EntityHealth>();
            PlayerStats player = col.GetComponent<PlayerStats>();
            if (enemy == null)
            {
                enemy = col.GetComponentInParent<EntityHealth>();
            }
            if (enemy != null)
            {
                // linear falloff of effect
                float proximity = (location - enemy.transform.position).magnitude;
                float effect = 1 - (proximity / radius);

                Vector3 explosionForce = (enemy.transform.position - transform.position) * 20f;
                enemy.Damage(damage);
                if(damage >= enemy.Health)
                {
                    enemy.ExplodeRagdoll(transform.position, explosiveForce);
                }

            }

            if (player != null)
            {
                player.DamagePlayer(damage * 0.25f, transform.position);
                player.GetComponent<CyberSpaceFirstPerson>().leftOverVelocity = ((player.transform.position - transform.position) + Vector3.up * 2f).normalized * playerExplosiveForce;
            }
        }

    }
}
