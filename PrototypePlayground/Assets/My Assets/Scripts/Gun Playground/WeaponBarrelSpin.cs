using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBarrelSpin : MonoBehaviour
{

    private float rotZ;
    private float rotZLerp;
    public float rotationSpeed;
    public float rotationDecay;
    public float acceleration;
    public float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(-180, rotZLerp, 0);
        rotZLerp = Mathf.Lerp(rotZLerp, rotZ, acceleration * Time.deltaTime);
        rotZ += Time.deltaTime * currentSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, 25f, rotationDecay * Time.deltaTime);
        currentSpeed = Mathf.Clamp(currentSpeed, 0, 1500f);
    }


    public void Increasespeed()
    {
        currentSpeed += rotationSpeed;
    }
}
