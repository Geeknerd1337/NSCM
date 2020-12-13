using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundTrigger : MonoBehaviour
{

    public UnityEvent triggerEvent;
    private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!triggered)
            {
                triggerEvent.Invoke();
                triggered = true;
            }
        }
    }
}
