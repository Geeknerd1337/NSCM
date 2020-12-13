using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
