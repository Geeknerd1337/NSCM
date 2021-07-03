using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This function will lerp our euler angles to a specified euler angle which can be added or subtracted to.
/// </summary>
public class OutputEulerRotator : OutputNode
{

    public override string IconPath => "Logic/OutputEuler.png";
    /// <summary>
    /// The initial Euler angles provided
    /// </summary>
    private Vector3 initialAngles;

    //The current angles to lerp to
    private Vector3 currentAngles = Vector3.zero;
    private Vector3 angle;

    /// <summary>
    /// How fast we lerp to the new angle
    /// </summary>
    public float rotationSpeed;

    void Start()
    {
        initialAngles = transform.eulerAngles;    
    }

    
    void Update()
    {
        LerpTo();
    }

    void LerpTo()
    {
        angle = Vector3.Lerp(angle, initialAngles + currentAngles, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(angle);
    }

    public void AddAngles(Vector3 vec)
    {
        currentAngles += vec;
    }

    //The below is like this because UnityEvents won't draw methods with vector3
    public void AddXAngle(float f)
    {
        currentAngles += new Vector3(f, 0, 0);
    }
    public void AddYAngle(float f)
    {
        currentAngles += new Vector3(0, f, 0);
    }
    public void AddZAngle(float f)
    {
        currentAngles += new Vector3(0, 0, f);
    }
}
