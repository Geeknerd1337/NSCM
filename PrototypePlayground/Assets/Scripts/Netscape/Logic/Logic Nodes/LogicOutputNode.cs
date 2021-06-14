using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class will trigger a unity event whenever all the inputs evlauate to their selected boolean value
/// </summary>
public class LogicOutputNode : LogicNode
{
    /// <summary>
    /// The events to output when inputs 
    /// </summary>
    public UnityEvent outputEvents;

    public List<LogicInput> inputs = new List<LogicInput>();

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
}


