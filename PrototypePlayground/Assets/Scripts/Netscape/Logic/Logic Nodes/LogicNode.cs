using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class LogicNode : MonoBehaviour
{
   
    public bool output { get; set; }
    public virtual string IconPath => "Logic/LogicNode.png";

    public enum State
    {
        True = 0,
        False = 1
    }
    public State validValue = State.True;
    
    




    public virtual void OnDrawGizmos()
    {
        // Draws the Light bulb icon at position of the object.
        // Because we draw it inside OnDrawGizmos the icon is also pickable
        // in the scene view.

        Gizmos.DrawIcon(transform.position, IconPath, true);
        

    }
}
