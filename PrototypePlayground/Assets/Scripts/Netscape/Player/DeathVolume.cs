using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that will put the player back at the latest valid fall position if they enter this volume. Typically placed at the bottom of a level
/// </summary>
public class DeathVolume : MonoBehaviour
{
    private FallManager fm;
    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FallManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fm.Die();
        }
    }
}
