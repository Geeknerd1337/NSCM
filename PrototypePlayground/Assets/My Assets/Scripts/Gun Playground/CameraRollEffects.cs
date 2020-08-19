using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRollEffects : MonoBehaviour
{
    public Vector3 rollVector;
    public Vector3 vectorAdditions;
    public Vector3 staticVectorAdditions;

    public Vector3 positionalVector;
    public Vector3 positionalVectorAdditions;

    [SerializeField] private float smoothing;
    [SerializeField] private float zeroSmoothing;
    [SerializeField] private float cameraPositionSpeed;
    [SerializeField] private float cameraPositionSmoothing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rollVector = Vector3.Lerp(rollVector, vectorAdditions + staticVectorAdditions, Time.deltaTime * smoothing);
        vectorAdditions = Vector3.Slerp(vectorAdditions, Vector3.zero, zeroSmoothing * Time.deltaTime);
        staticVectorAdditions = Vector3.Slerp(staticVectorAdditions, Vector3.zero, zeroSmoothing * Time.deltaTime);
        positionalVector = Vector3.Lerp(positionalVector, positionalVectorAdditions, cameraPositionSmoothing * Time.deltaTime);
        positionalVectorAdditions = Vector3.MoveTowards(positionalVectorAdditions, Vector3.zero, cameraPositionSpeed * Time.deltaTime);


    }
}
