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
        
        currentMoveTime = UnityEngine.Random.Range(0,moveTime);
    }

    void FixedUpdate()
    {
        float quinticEaseInOut (float x) { return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2; };
        currentMoveTime -= Time.fixedDeltaTime;
        Vector3 newPosition;
        float interpVal = quinticEaseInOut(currentMoveTime / moveTime);
       
        if (isMovingUp)
        {
            newPosition = Vector3.Lerp(lowPosition, highPosition, 1 - interpVal);
        }
        else
        {
            newPosition = Vector3.Lerp(lowPosition, highPosition, interpVal);
        }

        platformObject.transform.position = newPosition;

        if (currentMoveTime <= 0)
        {
            currentMoveTime = moveTime;
            isMovingUp = !isMovingUp;
        }

    }
}