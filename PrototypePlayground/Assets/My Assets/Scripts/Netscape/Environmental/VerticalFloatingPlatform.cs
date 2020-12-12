using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFloatingPlatform : MonoBehaviour
{
    public GameObject platformObject;
    // extracts the y-component to get a height offset
    public GameObject platformHighPositionObject;
    public float moveTime = 5.0f;

    private float currentMoveTime;
    private bool isMovingUp = true;

    private Vector3 lowPosition;
    private Vector3 highPosition;

    void Start()
    {
        lowPosition = platformObject.transform.position;
        highPosition = lowPosition;
        highPosition.y = platformHighPositionObject.transform.position.y;
    }

    void Update()
    {
        currentMoveTime -= Time.deltaTime;
        Vector3 newPosition;
        if (isMovingUp)
        {
            newPosition = Vector3.Lerp(lowPosition, highPosition, 1 - currentMoveTime / moveTime);
        }
        else
        {
            newPosition = Vector3.Lerp(lowPosition, highPosition, currentMoveTime / moveTime);
        }
        platformObject.transform.position = newPosition;
    }
}