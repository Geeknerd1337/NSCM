/********************************************************************************************************
 * 
 * ***NAME***
 * snapToFloor
 * 
 * ***DESCRIPTION***
 * basic script to ensure whatever object attached starts on the floor
 * 
 * ***USAGE***
 * Place onto any gameobject
 * 
 * ***AUTHOR***
 * Natalie Soltis
 * 
 * 
 * ***GENERAL TODO***
 * 
 * 
 * * none as-of 2/28
 * * note 1-19-21 HOLY SHIT 2/28?! GOD IT HAS BEEN THAT LONG!?
 * 
 *******************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class snapToFloor : MonoBehaviour
{
    [Tooltip("If to or not destroy this object if it cannot find a surface to snap itself to")]
    [SerializeField]
    private bool destroyIfCantSnap = false;

    // Start is called before the first frame update
    private void Awake()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(0, -float.MaxValue, 0));
        if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, float.MaxValue))
        {
            print("got here");
            transform.position = new Vector3(transform.position.x, hit.collider.bounds.ClosestPoint(transform.position).y + GetComponent<Collider>().bounds.extents.y, transform.position.z);
        }
        else if (destroyIfCantSnap) Destroy(this.gameObject);
    }
}
