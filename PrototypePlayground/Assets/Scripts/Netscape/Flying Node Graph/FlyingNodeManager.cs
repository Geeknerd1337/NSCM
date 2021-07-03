using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FlyingNodeManager : MonoBehaviour
{

    /// <summary>
    /// A list of our flying nodes
    /// </summary>
    [SerializeField]
    List<FlyingNode> Nodes = new List<FlyingNode>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BakeNodes()
    {
        GetNodes();
        foreach(FlyingNode n in Nodes)
        {
            n.GetNeighbors();
        }
    }

    public void ClearNodes()
    {
        foreach (FlyingNode n in Nodes)
        {
            n.Neighbors.Clear();
        }
        Nodes.Clear();
    }

    public void GetNodes()
    {
        Nodes.Clear();
        Nodes = GetComponentsInChildren<FlyingNode>().ToList<FlyingNode>();
    }

    public void ToggleGizmos()
    {
        GetNodes();
        foreach(FlyingNode n in Nodes)
        {
            n.drawGizmos = !n.drawGizmos;
        }
    }

    public void ToggleWireGizmos()
    {
        GetNodes();
        foreach (FlyingNode n in Nodes)
        {
            n.drawWireSpheres = !n.drawWireSpheres;
        }
    }
}
