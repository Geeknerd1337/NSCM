using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputMaterialPropertySet : OutputNode
{

    public LogicNode inputNode;
    public Renderer[] rend;
    public int materialIndex;
    public string property;
    public Color onColor;
    public Color offColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputNode == null)
        {
            return;
        }
        foreach(Renderer r in rend)
        {
            r.materials[materialIndex].SetColor(property, (inputNode.output == true) ? onColor : offColor);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if(inputNode != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, inputNode.transform.position);
            Gizmos.color = Color.white;
        }
        Gizmos.color = Color.green;
        foreach (Renderer r in rend)
        {
            Gizmos.DrawLine(transform.position, r.transform.position);
        }
        Gizmos.color = Color.white;
    }
}
