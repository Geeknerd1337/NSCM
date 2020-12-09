using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAttack : MonoBehaviour
{

    public ParticleSystem part;
    public float damage;
    public float blastRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Explode()
    {
        AreaDamageEnemies(transform.position, blastRadius, damage);
        part.Play();
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            PlayerStats enemy = col.GetComponent<PlayerStats>();
            if (enemy != null)
            {
                // linear falloff of effect
                float proximity = (location - enemy.transform.position).magnitude;
                float amt = Mathf.Clamp01(proximity / radius);
                float effect = 1 - amt;


                enemy.DamagePlayer(damage * effect, transform.position);
            }
        }

    }
}
