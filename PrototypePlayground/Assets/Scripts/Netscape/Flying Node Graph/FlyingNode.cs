using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BoxCollider))]
public class FlyingNode : MonoBehaviour
{
    /// <summary>
    /// A list of the nodes we are connected to
    /// </summary>
    public List<FlyingNode> Neighbors;

    /// <summary>
    /// The radius for which our node will search for other nodes
    /// </summary>
    [SerializeField]
    private float searchRadius = 20f;

    /// <summary>
    /// The 'thickness' of the ray casted between us and our neighbors to establish a valid connection
    /// </summary>
    [SerializeField]
    private float searchThickness = 20f;

    /// <summary>
    /// The max amount of neighbors we're allowed to have
    /// </summary>
    [SerializeField]
    private int maxNeighbors = 6;

    [HideInInspector]
    public bool drawWireSpheres = true;

    [HideInInspector]
    public bool drawGizmos = true;

    /// <summary>
    /// A layermask for only overlapping with nodes
    /// </summary>
    [SerializeField]
    private LayerMask lm;

    /// <summary>
    /// A mask for when we're sphere casting to our potential neighbors;
    /// </summary>
    [SerializeField]
    private LayerMask neighborMask;

    /// <summary>
    /// The gCost of this node
    /// </summary>
    public float gCost;

    /// <summary>
    /// The hcost of this node
    /// </summary>
    public float hCost;

    /// <summary>
    /// The fcost of this node
    /// </summary>
    public float fCost{
        get
        {
            return gCost + hCost;
        }
    }

    public FlyingNode parent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNeighbors()
    {
        List<Collider> localNeighbors = Physics.OverlapBox(transform.position,Vector3.one *  searchRadius / 2f,transform.rotation,lm).OrderBy(c => (transform.position - c.transform.position).sqrMagnitude).ToList();
        Neighbors.Clear();
        int curNeighbors = 0;
        Debug.Log(name + " " + localNeighbors.Count.ToString());
        for (int i = 0; i < localNeighbors.Count; i++)
        {
            
            Transform t = localNeighbors[i].transform;
            Ray ray = new Ray(transform.position, (t.position - transform.position));
            bool hit = Physics.SphereCast(ray, searchThickness, searchRadius / 2,neighborMask);
            if (!hit && curNeighbors < maxNeighbors)
            {
                curNeighbors++;
                Neighbors.Add(localNeighbors[i].GetComponent<FlyingNode>());
            }
            
        }
    }

    public void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawIcon(transform.position, "AI/FlyingNode.png");
            Gizmos.color = Color.blue;
            if (drawWireSpheres)
            {
                Gizmos.DrawWireCube(transform.position, Vector3.one * searchRadius / 2);
            }
            Gizmos.color = Color.yellow;
            foreach(FlyingNode n in Neighbors)
            {
                Gizmos.DrawLine(transform.position, n.transform.position);
            }

            Gizmos.color = Color.white;
        }
    }
}
