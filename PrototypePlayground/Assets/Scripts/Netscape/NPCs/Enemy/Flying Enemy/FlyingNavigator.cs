using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingNavigator : MonoBehaviour
{

    public FlyingNodeManager Manager;
    public CyberSpaceFirstPerson fps;
    public List<FlyingNode> MyPath;
    // Start is called before the first frame update
    void Start()
    {
        fps = FindObjectOfType<CyberSpaceFirstPerson>();
        Manager = FindObjectOfType<FlyingNodeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            
        }

        
    }

    private void OnDrawGizmos()
    {
        if (MyPath != null && MyPath.Count >= 2)
        {
            Gizmos.color = (Color.blue);
            for (int i = 1; i < MyPath.Count; i++)
            {

                Gizmos.DrawLine(MyPath[i].transform.position + Vector3.up * 0.05f, MyPath[i - 1].transform.position + Vector3.up * 0.05f);
                Gizmos.DrawWireSphere(MyPath[i].transform.position, 1f);
                Gizmos.DrawWireSphere(MyPath[i - 1].transform.position, 1f);
            }
            Gizmos.color = (Color.white);
        }
    }
}
