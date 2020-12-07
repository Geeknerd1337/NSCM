using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallDirectionalLightController : MonoBehaviour
{
    public float speed = 1.0f;
    // how much it deviates from its original value
    public float strength = 0.25f;

    void Start()
    {
        _light = GetComponent<Light>();
        if (_light == null)
        {
            Debug.LogError("no light component");
        }
        else
        {
            _originalShadowStrength = _light.shadowStrength;
        }
    }

    void Update()
    {
        if (_light != null)
        {
            _accumulatedTime += Time.deltaTime * speed;
            var sin = Mathf.Sin(_accumulatedTime) ;
            sin = (sin - (float)Math.Truncate(sin)) * strength;
            _light.shadowStrength = _originalShadowStrength + sin;
        }
    }
    float _originalShadowStrength;
    float _accumulatedTime = 0.0f;
    Light _light;
}