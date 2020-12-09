using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityProjectile : MonoBehaviour
{
    public float speed;

    public bool damagePlayer;
    public float damage;

    public float life;

    public GameObject onDestroyCreate;

    public Transform creator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        life -= Time.deltaTime;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (damagePlayer)
        {
            if(other.tag == "Player")
            {
                PlayerStats p = other.GetComponent<PlayerStats>();
                if(p != null)
                {
                    if (creator == null)
                    {
                        p.DamagePlayer(damage, transform.position);
                    }
                    else
                    {
                        p.DamagePlayer(damage, creator.position);
                    }
                    if(onDestroyCreate != null)
                    {
                        GameObject g = Instantiate(onDestroyCreate);
                        g.transform.position = transform.position;
                        Destroy(g, 5f);
                    }
                    Destroy(gameObject);
                }
            }
            else
            {
                if (onDestroyCreate != null)
                {
                    GameObject g = Instantiate(onDestroyCreate);
                    g.transform.position = transform.position;
                    Destroy(g, 5f);
                }
                Destroy(gameObject);
            }

            
        }
    }

    private void OnDestroy()
    {
        if (onDestroyCreate != null)
        {
            //GameObject g = Instantiate(onDestroyCreate);
            //g.transform.position = transform.position;
           // Destroy(g, 5f);
        }
    }
}
