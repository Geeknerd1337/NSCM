using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpEffects : MonoBehaviour
{

    public Transform weaponImage;
    private Transform fps;
    // Start is called before the first frame update
    void Start()
    {
        fps = FindObjectOfType<CyberSpaceFirstPerson>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        weaponImage.LookAt(fps);
    }
}
