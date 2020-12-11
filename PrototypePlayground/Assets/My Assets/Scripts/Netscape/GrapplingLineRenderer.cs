using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingLineRenderer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer rend;
    private float dist;


    public Transform origin;
    public Transform desination;
    public int segments;

    public float wave = 1f;
    public float amp = 1f;

    [Header("Animation Curve")]
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float curveAmt;
    [SerializeField] private float curveSize;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private AnimationCurve curveEffectCurve;
    [SerializeField] private AnimationCurve curveEffectOverTime;
    [Range(0, 1)]
    [SerializeField] private float effectTime;
    [SerializeField] private float effectSpeed;

    public float slide1;
    public float slide2;
    private float scrollAmt;
    public bool destroyOnFinish;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<LineRenderer>();
        rend.SetPosition(0, origin.position);
        rend.positionCount = segments;
        effectTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (effectTime < 1)
        {
            effectTime += effectSpeed * Time.deltaTime;

        }
        else
        {
            effectTime = 1;
            if (destroyOnFinish)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        DrawLine();
    }


    void DrawLine()
    {
        Vector3 pointA = origin.position;
        Vector3 pointB = desination.position;
        dist = Vector3.Distance(pointA, pointB);
        Vector3 rotDir = (pointB - pointA);
        origin.rotation = Quaternion.LookRotation(rotDir.normalized);

        Vector3[] pointsBuffer = new Vector3[segments];
        scrollAmt += scrollSpeed * Time.deltaTime;

        for (int i = 0; i < segments; i++)
        {
            Vector3 pointAlongLine = (i * (dist / segments) * Vector3.Normalize(rotDir)) + pointA;

            float amt = i / (float)segments;
            pointAlongLine += curveEffectOverTime.Evaluate(effectTime) * curveEffectCurve.Evaluate(amt) * ((-origin.transform.right * slide1 + origin.transform.up * slide2).normalized * (curveAmt * curve.Evaluate((amt + scrollAmt) * curveSize)));




            pointsBuffer[i] = pointAlongLine;
        }
        pointsBuffer[segments - 1] = pointB;

        rend.SetPositions(pointsBuffer);
    }

}
