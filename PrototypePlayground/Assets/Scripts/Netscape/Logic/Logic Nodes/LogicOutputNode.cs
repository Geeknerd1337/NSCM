using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class will trigger a unity event whenever all the inputs evlauate to their selected boolean value
/// </summary>
[System.Serializable]
public class LogicOutputNode : LogicNode
{
    /// <summary>
    /// The events to output when inputs 
    /// </summary>
    public UnityEvent outputEvents;

    [SerializeField]
    public List<LogicNode> inputs = new List<LogicNode>();

    private bool triggered;

    private void Update()
    {
        bool b = true;
        for (int i = 0; i < inputs.Count; i++)
        {
            if (!inputs[i].output)
            {
                b = false;
            }
        }

        if (b && !triggered)
        {
            outputEvents.Invoke();
            triggered = true;
        }


    }

    public override void OnDrawGizmos()
    {
        // Draws the Light bulb icon at position of the object.
        // Because we draw it inside OnDrawGizmos the icon is also pickable
        // in the scene view.
        Gizmos.DrawIcon(transform.position, "Logic/OutputNode.png", true);
        for (int i = 0; i < inputs.Count; i++)
        {

            if (inputs[i] != null)
            {
                Gizmos.DrawLine(transform.position, inputs[i].transform.position);
            }

        }
       
    }
}


