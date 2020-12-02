using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionUI : MonoBehaviour
{

    public List<WeaponSlot> weaponSlots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public WeaponSlot SelectWeapon(int i)
    {
        foreach (WeaponSlot w in weaponSlots)
        {
            w.wt.weaponsOpen = false;
            w.selected = false;
        }
        WeaponSlot weaponSlot = weaponSlots[i];

        if (!weaponSlot.wt.weaponsOpen)
        {
            weaponSlot.wt.weaponsOpen = true;
        }

        weaponSlot.selected = true;
        return weaponSlot;
    }

    public bool SlotHasWeapon(int i)
    {
        WeaponSlot weaponSlot = weaponSlots[i];
        if (weaponSlot.HasWeapon)
        {
            return true;
        }

        return false;
    }
}
