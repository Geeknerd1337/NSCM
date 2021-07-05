using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Linq;

public class FlyingNodeManager : MonoBehaviour
{

    /// <summary>
    /// A list of our flying nodes
    /// </summary>
    [SerializeField]
    List<FlyingNode> Nodes = new List<FlyingNode>();

    FlyingNode starter;
    FlyingNode end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<FlyingNode> FindPath(Vector3 start, Vector3 target)
    {
        FlyingNode startNode = NodeFromWorldPoint(start);
        FlyingNode targetNode = NodeFromWorldPoint(target);

        starter = startNode;
        end = targetNode;



        List<FlyingNode> openSet = new List<FlyingNode>();
        HashSet<FlyingNode> closedSet = new HashSet<FlyingNode>();
        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            FlyingNode currentNode = openSet[0];
            

            for(int i = 1; i < openSet.Count; i++)
            {
                if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                
                return RetracePath(startNode, targetNode);
            }

            foreach(FlyingNode neighbor in currentNode.Neighbors)
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                float newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if(newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }

            }
        }

        return null;
    }

    List<FlyingNode> RetracePath(FlyingNode startNode, FlyingNode targetNode)
    {
        List<FlyingNode> nodes = new List<FlyingNode>();
        FlyingNode currentNode = targetNode;

        while(currentNode != startNode)
        {
            nodes.Add(currentNode);
            currentNode = currentNode.parent;
        }

        nodes.Reverse();

        return nodes;

    }

    /// <summary>
    /// Gets the distance between two nodes
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    float GetDistance(FlyingNode a, FlyingNode b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }


    /// <summary>
    /// Gets the nearest flying node from a given position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public FlyingNode NodeFromWorldPoint(Vector3 position)
    {
        FlyingNode n = null;
        float maxDist = float.MaxValue;
        for(int i = 0; i < Nodes.Count; i++)
        {
            float dist = Vector3.Distance(position, Nodes[i].transform.position);
            if(dist < maxDist)
            {
                maxDist = dist;
                n = Nodes[i];
            }
        }
        return n;
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

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (starter != null)
        {
            Gizmos.DrawWireSphere(starter.transform.position, 3f);
        }
        if (end != null)
        {
            Gizmos.DrawWireSphere(end.transform.position, 3f);
        }
    }
}
