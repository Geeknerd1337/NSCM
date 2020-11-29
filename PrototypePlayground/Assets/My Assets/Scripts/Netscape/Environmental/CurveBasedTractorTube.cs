using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CurveBasedTractorTube : MonoBehaviour
{
    public PathCreator p;

    public float tractorSpeed;
    public CyberSpaceFirstPerson player;
    public bool isTravelling;
    public float followQuality;
    [SerializeField]
    private float targetTime = 0;
    Vector3 targetPosition = Vector3.zero;
    

    private void Start()
    {
        player = FindObjectOfType<CyberSpaceFirstPerson>();
    }

    private void Update()
    {
        if (isTravelling)
        {
            if (player != null)
            {
                //Debug.DrawRay(transform.position, transform.up * 100,Color.red);
                // Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
                //Debug.DrawRay(transform.position, transform.right * 100, Color.green);

                //Vector3 dir = GetClosestPointOnInfiniteLine(csfp.transform.position, transform.position, transform.position + (transform.up * 10f)) - csfp.transform.position;
                Vector3 dir = (targetPosition - player.transform.position);
                Vector3 totalDir = dir;
                if (Vector3.Distance(targetPosition, player.transform.position) < 1f)
                {
                    Debug.Log("WHAT");
                    targetPosition = p.path.GetPointAtTime(targetTime);
                    targetTime += 1/followQuality;

                }
                Debug.DrawRay(player.transform.position, totalDir, Color.white);
                player.AddDirVector = totalDir.normalized * tractorSpeed;
                //Debug.DrawRay(csfp.transform.position, csfp.AddDirVector * 100, Color.white);

                //Debug.Break();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!isTravelling)
            {
                targetTime = p.path.GetClosestTimeOnPath(player.transform.position);
                targetPosition = p.path.GetPointAtTime(targetTime);
                targetTime += 1 / followQuality;
            }
            isTravelling = true;
            
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CyberSpaceFirstPerson csfp = other.GetComponent<CyberSpaceFirstPerson>();
            if (csfp != null)
            {
                //Debug.DrawRay(transform.position, transform.up * 100,Color.red);
                // Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);
                //Debug.DrawRay(transform.position, transform.right * 100, Color.green);

                //Vector3 dir = GetClosestPointOnInfiniteLine(csfp.transform.position, transform.position, transform.position + (transform.up * 10f)) - csfp.transform.position;
                Vector3 dir = (csfp.transform.position - NearestPoint(csfp.transform.position)).normalized;
                Vector3 totalDir = dir;
                Debug.DrawRay(csfp.transform.position, totalDir, Color.white);
                csfp.AddDirVector = totalDir.normalized * tractorSpeed;
                //Debug.DrawRay(csfp.transform.position, csfp.AddDirVector * 100, Color.white);

                //Debug.Break();
            }
        }
    }*/
    Vector3 NearestPoint(Vector3 position)
    {
        return p.path.GetClosestPointOnPath(position);
    }
}
