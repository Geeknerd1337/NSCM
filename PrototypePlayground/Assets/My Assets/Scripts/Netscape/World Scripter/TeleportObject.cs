using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A class for moving one transform to the location of another
/// </summary>
public class TeleportObject : MonoBehaviour
{
    /// <summary>
    /// The transform we are going to teleport
    /// </summary>
    [SerializeField]
    private Transform traveller;

    /// <summary>
    /// The transform we are teleporting the traveller to
    /// </summary>
    [SerializeField]
    private Transform destination;

    /// <summary>
    /// An event to be invoked when the traveller is teleported
    /// </summary>
    [SerializeField]
    private UnityEvent teleportEvents;
    
    /// <summary>
    /// Teleports the traveller transform to the destination, invoking the teleport events.
    /// </summary>
    public void Teleport()
    {
        traveller.transform.position = destination.position;
        teleportEvents.Invoke();
        //This ensures the player will be teleported
        Physics.SyncTransforms();
    }
}
