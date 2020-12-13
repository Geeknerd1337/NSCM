using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOscillator : MonoBehaviour
{
    
    void Start()
    {
            
    }

    void Update()
    {
        Quaternion rotation = Quaternion.identity;
        var sin = Mathf.Sin(Time.time);
        rotation.y += (2 * Time.deltaTime) + (sin * Time.deltaTime);
        gameObject.transform.Rotate(rotation.eulerAngles);
    }
}
