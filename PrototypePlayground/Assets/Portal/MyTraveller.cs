using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MyTraveller : PortalTraveller
{

    public Transform position;

    private void Update()
    {
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        FirstPersonController fps = GetComponent<FirstPersonController>();
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle(transform.rotation.eulerAngles.y, eulerRot.y);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + delta,transform.rotation.eulerAngles.z));
        Debug.Log(transform.position);
        Debug.Log(transform.name);
        //transform.eulerAngles = Vector3.up * (delta);
        
        Physics.SyncTransforms();

    }
}
