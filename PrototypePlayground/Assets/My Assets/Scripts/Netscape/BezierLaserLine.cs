using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierLaserLine : MonoBehaviour
{

    private LineRenderer rend;
    [SerializeField]
    public int segments;
    [SerializeField]
    public Transform origin, point, destination;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<LineRenderer>();

        rend.positionCount = segments;
    }

    // Update is called once per frame
    void Update()
    {
        DrawQuadCurve();
    }


    void DrawQuadCurve()
    {
        Vector3[] pointsBuffer = new Vector3[segments];
        for (int i = 0; i < segments; i++)
        {
            float t = (i + 1) / (float)segments;
            pointsBuffer[i] = CalculateQuadraticBezierPoint(t, origin.localPosition, point.localPosition, destination.localPosition);
        }
        rend.SetPositions(pointsBuffer);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 P2)
    {
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        return p + (2 * u * t * p1) + (tt * P2);
    }

    private void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        Gizmos.color = Color.red;

        //Draw the suspension
        Gizmos.DrawSphere(destination.position,0.25f);
        Gizmos.DrawSphere(origin.position, 0.25f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(point.position, 0.25f);
        


        Gizmos.color = Color.white;
        #endif
    }
}
