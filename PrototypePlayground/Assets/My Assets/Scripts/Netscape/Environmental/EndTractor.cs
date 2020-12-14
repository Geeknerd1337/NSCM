using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTractor : MonoBehaviour
{
    public AudioSource loop;
    public CurveBasedTractorTube myTube;
    public float speedCoefficient; 
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
            myTube.player.leftOverVelocity = transform.forward * myTube.tractorSpeed * speedCoefficient;
            myTube.isTravelling = false;
            loop.Stop();
            
        }
    }
}
