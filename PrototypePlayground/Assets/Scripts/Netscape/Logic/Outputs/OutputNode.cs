using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Output nodes are very simple. In effect, these 'Do Something'. You can use them to manipulate the world
/// in various ways and perform general events and behaviors that can be abstracted or used by the I/O system
/// </summary>
public class OutputNode : MonoBehaviour
{
    /// <summary>
    /// A path to the icon drawn in the world, used for the inspector, not in game.
    /// </summary>
    public virtual string IconPath => "Logic/OutputNode.png";

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, IconPath, true);
    }
}
