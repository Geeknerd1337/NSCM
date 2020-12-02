using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTitle : MonoBehaviour
{
    private bool trig;
    public GameObject title;
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!trig)
            {
                title.SetActive(true);
                trig = true;
            }
        }
    }
}
