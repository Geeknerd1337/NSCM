using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{

    public List<GameObject> guns;
    private int gunIndex;
    private int gunIndexActual;
    public Weapon currentWeapon;

    [SerializeField]
    private GunSelectionUI gunUI;

    // Start is called before the first frame update
    void Start()
    {
        gunIndex = 0;
        gunIndexActual = 0;
        ActivateGun(gunIndexActual);
  
        gunUI = FindObjectOfType<GunSelectionUI>();
        gunUI.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollWeapon();
    }

    void ScrollWeapon()
    {
        float f = Input.mouseScrollDelta.y;

        if(Mathf.Abs(f) > 0)
        {
            if (!gunUI.gameObject.activeSelf)
            {
                gunUI.gameObject.SetActive(true);
            }
        }

        if(f > 0)
        {
            Decrement();
        }

        if(f < 0)
        {
            Increment();
        }


        

        WeaponSlot w = gunUI.SelectWeapon(gunIndex);
        if (Input.GetMouseButtonDown(0))
        {
            ActivateGun(w.gunIndex);
            gunUI.gameObject.SetActive(false);
        }
    }

    void Increment()
    {
        gunIndex++;

        

        if(gunIndex > gunUI.weaponSlots.Count - 1)
        {
            gunIndex = 0;
        }

        while (!gunUI.SlotHasWeapon(gunIndex))
        {
            gunIndex++;
            if (gunIndex > gunUI.weaponSlots.Count - 1)
            {
                gunIndex = 0;
            }
        }
    }

    public void UnlockWeapon(int i)
    {
        gunUI.gameObject.SetActive(true);
        gunUI.weaponSlots[i].HasWeapon = true;
        gunUI.SelectWeapon(i);
        gunIndex = i;
        ActivateGun(i);
        gunUI.gameObject.SetActive(false);
    }

    void Decrement()
    {
        gunIndex--;
        if(gunIndex < 0)
        {
            gunIndex = gunUI.weaponSlots.Count - 1;
        }

        while (!gunUI.SlotHasWeapon(gunIndex))
        {
            gunIndex--;
            if (gunIndex < 0)
            {
                gunIndex = gunUI.weaponSlots.Count - 1;
            }
        }
    }

    void ActivateGun(int gun)
    {
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == gun)
            {
                guns[i].SetActive(true);
                gunIndexActual = i;
            }
            else
            {
                guns[i].SetActive(false);
            }

            currentWeapon = CurrentWeapon();
        }
    }

    public Weapon GetWeaponFromIndex(int i )
    {
        return guns[i].GetComponent<Weapon>();
    }

    public Weapon CurrentWeapon()
    {
        if (guns[gunIndexActual] != null)
        {
            return guns[gunIndexActual].GetComponent<Weapon>();
        }
        else
        {
            return null;
        }
    }
}