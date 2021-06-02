using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A class that references the fall manager and sets a new valid position when the player enters the trigger
/// </summary>
public class NewFallPosition : MonoBehaviour
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
        if (other.tag == "Player")
        {
            fm.originalPosition = transform.position;
        }
    }
}
