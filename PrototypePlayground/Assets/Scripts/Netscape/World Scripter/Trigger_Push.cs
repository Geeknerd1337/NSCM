using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Push : MonoBehaviour
{
    public Vector3 wayToPush;
    public bool doOnlyOnPlayer;

    private void OnTriggerStay(Collider other)
    {
        print("yo im workin ");
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CyberSpaceFirstPerson>().leftOverVelocity += wayToPush;
        }
        if (doOnlyOnPlayer) return;

    }
}
