using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This will output as true if the selected transform's match the provided vector3 within a certain tolerance
/// </summary>
public class EqualsEulerAngle : LogicNode
{

    public override string IconPath => "Logic/Euler.png";
    /// <summary>
    /// The transform we are checking against
    /// </summary>
    public Transform targetTransform;
    /// <summary>
    /// The euler angle we want to check against. 
    /// </summary>
    public Vector3 targetEuler;



    /// <summary>
    /// How 'close' to the value we want to be in order to have our output be true
    /// </summary>
    [Range(0, 10)]
    public float tolerance;

    // Update is called once per frame
    void Update()
    {
        FireInput();

    }

    public override void FireInput()
    {
        if (targetTransform != null)
        {
            float ang = Quaternion.Angle(Quaternion.Euler(targetTransform.localEulerAngles), Quaternion.Euler(targetEuler));

            if (ang < tolerance)
            {
                output = true;
            }
            else
            {
                output = false;
            }
        }
        else
        {
            output = false;
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if(targetTransform != this.transform && targetTransform != null)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, targetTransform.position);
            Gizmos.color = Color.white;
        }
    }
}
