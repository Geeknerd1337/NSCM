using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public List<GameObject> guns;
    private int gunIndex;
    // Start is called before the first frame update
    void Start()
    {
        gunIndex = 0;
        ActivateGun();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Increment();
            ActivateGun();
        }
    }

    void Increment()
    {
        gunIndex++;
        if(gunIndex > guns.Count - 1)
        {
            gunIndex = 0;
        }
    }

    void ActivateGun()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == gunIndex)
            {
                guns[i].SetActive(true);
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }
}
