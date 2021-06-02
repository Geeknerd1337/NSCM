using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorTube : MonoBehaviour
{
    public float tractorSpeed;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            CyberSpaceFirstPerson csfp = other.GetComponent<CyberSpaceFirstPerson>();
            if (csfp != null)
            {
                //Debug.DrawRay(transform.position, transform.up * 100,Color.red);
               // Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
                //Debug.DrawRay(transform.position, transform.right * 100, Color.green);

                Vector3 dir = GetClosestPointOnInfiniteLine(csfp.transform.position, transform.position, transform.position + (transform.up * 10f)) - csfp.transform.position;
                
                Vector3 totalDir = transform.up + dir;
                Debug.DrawRay(csfp.transform.position, totalDir, Color.white);
                csfp.AddDirVector = totalDir.normalized * tractorSpeed;
                //Debug.DrawRay(csfp.transform.position, csfp.AddDirVector * 100, Color.white);
                
                //Debug.Break();
            }
        }
    }

    // For infinite lines:
    Vector3 GetClosestPointOnInfiniteLine(Vector3 point, Vector3 line_start, Vector3 line_end)
    {
        return line_start + Vector3.Project(point - line_start, line_end - line_start);
    }
}
