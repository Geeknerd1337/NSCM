using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteractionEvent : Interaction
{
    public UnityEvent myEvents;
    public override void interaction()
    {
        base.interaction();
        myEvents.Invoke();
    }
}
