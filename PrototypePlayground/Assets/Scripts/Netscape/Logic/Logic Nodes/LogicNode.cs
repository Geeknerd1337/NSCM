using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Logic nodes are the background of the I/O system. They have a true or false value, which will output true or false
/// based on whether or not the output matches the state set in validValue
/// </summary>
[DisallowMultipleComponent]
public class LogicNode : MonoBehaviour
{
    /// <summary>
    /// A path to the icon drawn in the world, used for the inspector, not in game.
    /// </summary>
    public virtual string IconPath => "Logic/LogicNode.png";
    /// <summary>
    /// The public output variable of the node
    /// </summary>
    [SerializeField]
    public bool output;
    

    /// <summary>
    /// An enumerator for the state
    /// </summary>
    public enum State
    {
        True = 0,
        False = 1
    }
    /// <summary>
    /// The valid value of our input
    /// </summary>
    public State validValue = State.True;
    
    
    /// <summary>
    /// Fire input will set our input to be true or false based on the evaluated statement. This can be used in logic
    /// nodes so logic can be checked once rather than every frame, even though some nodes will call this every frame
    /// </summary>
    public virtual void FireInput()
    {

    }


    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, IconPath, true);
    }
}
