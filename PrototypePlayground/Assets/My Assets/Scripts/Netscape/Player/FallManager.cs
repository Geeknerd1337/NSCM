using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    public ParticleSystem part;
    public AudioSource a;
    public Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        PlayerStats p = GetComponent<PlayerStats>();
        if(p != null)
        {
            p.DamagePlayer(5f, transform.position);
        }
        a.Play();
        part.Play();

        transform.position = originalPosition;
        Physics.SyncTransforms();
    }
}
