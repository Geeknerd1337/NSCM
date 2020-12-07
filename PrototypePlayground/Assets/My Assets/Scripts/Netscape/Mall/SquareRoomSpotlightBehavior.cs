using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRoomSpotlightBehavior : MonoBehaviour
{
    public Light spotLight;
    public float spotLightAngleSmall = 1.0f;
    public float spotLightAngleLarge = 88.0f;

    void Start()
    {
        
    }

    void Update()
    {
        var sin = Mathf.Sin(Time.time);
        spotLight.spotAngle = Mathf.Lerp(spotLightAngleSmall, spotLightAngleLarge, sin);
        spotLight.shadowBias = sin;
    }
}
