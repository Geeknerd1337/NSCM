using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDRelay : Relay
{
    public override string IconPath => "Logic/ANDRelay.png";
    public LogicNode inputNode;
    public LogicNode inputNode2;

    void Update()
    {
        FireInput();
    }

    public override void FireInput()
    {
        bool check = (int)validValue == 1 ? false : true;

        output = (inputNode2.output == check && inputNode.output == check);
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (inputNode2 != null)
        {
            Gizmos.DrawLine(transform.position, inputNode2.transform.position);
        }
        if (inputNode != null)
        {
            Gizmos.DrawLine(transform.position, inputNode.transform.position);
        }
    }

}
