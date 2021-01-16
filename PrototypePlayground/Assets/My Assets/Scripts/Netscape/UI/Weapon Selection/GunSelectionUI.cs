using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionUI : MonoBehaviour
{

    public List<WeaponSlot> weaponSlots;
    public List<GunCategories> weaponCategories;
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

        if (!weaponSlot.wt.weaponsOpen && weaponSlot.HasWeapon)
        {
            weaponSlot.wt.weaponsOpen = true;
        }

        if (weaponSlot.HasWeapon)
        {
            weaponSlot.selected = true;
        }
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

    public void ResetAllGunCategories()
    {
        foreach(GunCategories category in weaponCategories)
        {
            category.index = 0;
        }
    }

    public int GetSlotFromCategory(int i)
    {
        GunCategories gunCat = weaponCategories[i];
        int indice = 0;
        for(int b = 0; b < i; b++)
        {
            indice += weaponCategories[b].weaponSlots.Count;
        }

        int numChecks = gunCat.weaponSlots.Count;
        int checkIndice = 0;

        while(!SlotHasWeapon(gunCat.index + indice))
        {
            gunCat.Increment();
            checkIndice++;

            if (checkIndice > numChecks)
            {
                return -1;
            }
        }

        Debug.Log("Indice: " + (gunCat.index + indice).ToString());

        return gunCat.index + indice;

    }
}

[System.Serializable]
public class GunCategories{
    public List<WeaponSlot> weaponSlots;
    [HideInInspector]
    public int index = 0;
    public void Increment()
    {
        index++;
        if(index >= weaponSlots.Count)
        {
            index = 0;
        }
    }

    public int GetWeaponSlot(int i)
    {
        return index * weaponSlots.Count + i;
        
    }
}
