using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRoomExitTrigger : MonoBehaviour
{
    public SquareRoomController controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.OnExitTrigger();    
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
