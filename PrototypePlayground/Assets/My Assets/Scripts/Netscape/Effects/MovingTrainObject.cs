using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrainObject : MonoBehaviour
{

    public Vector3 direction;
    public float range;
    public float speed;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if(Vector3.Distance(transform.position,originalPosition) >= range)
        {
            transform.position = originalPosition - direction * range * 0.99f;
        }
    }
}
