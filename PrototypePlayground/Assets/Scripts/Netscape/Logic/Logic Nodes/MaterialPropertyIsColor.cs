using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyIsColor : LogicNode
{

    public Renderer rend;
    public int materialIndex;
    public string property;
    public Color checkColor;

    

    // Update is called once per frame
    void Update()
    {
        FireInput();
    }

    public override void FireInput()
    {
        base.FireInput();
        if(rend.materials[materialIndex].GetColor(property) == checkColor)
        {
            output = true;
        }
        else
        {
            output = false;
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if(rend != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, rend.transform.position);
            Gizmos.color = Color.white;
        }
    }


}
