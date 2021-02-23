using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A series of vector3s that control the rotation of the camera and the shake of the camera. Helps with animating things bullets kicking the camera up slightly or landing from a great distance.
/// </summary>
public class CameraRollEffects : MonoBehaviour
{
    /// <summary>
    /// The roll vector for the camera
    /// </summary>
    public Vector3 rollVector;
    /// <summary>
    /// Aditions to the roll vector we're making
    /// </summary>
    public Vector3 vectorAdditions;
    /// <summary>
    /// A static, unmoving set of vector additions. Unsure why this is till here 
    /// TODO: See about depreciating
    /// </summary>
    public Vector3 staticVectorAdditions;

    public Vector3 positionalVector;
    public Vector3 positionalVectorAdditions;

    /// <summary>
    /// The smoothing value for rotation
    /// </summary>
    [SerializeField] private float smoothing;
    /// <summary>
    /// The smoothing value for taking vector additions back down to zero.
    /// </summary>
    [SerializeField] private float zeroSmoothing;
    /// <summary>
    /// The speed at which the camera moves to a position
    /// </summary>
    [SerializeField] private float cameraPositionSpeed;
    /// <summary>
    /// How smoothly a camera moves to a position
    /// </summary>
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
