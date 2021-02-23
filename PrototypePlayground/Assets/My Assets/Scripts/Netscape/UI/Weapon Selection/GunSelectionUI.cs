using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelectionUI : MonoBehaviour
{
    /// <summary>
    /// List of weapon slots
    /// </summary>
    public List<WeaponSlot> weaponSlots;
    /// <summary>
    /// List of weapon categories
    /// </summary>
    public List<GunCategories> weaponCategories;
    
    /// <summary>
    /// This will select a weapon from a given index on the weapon slots list and set thatslot to be open and selected
    /// </summary>
    /// <param name="i">Index for the slot we are selecting</param>
    /// <returns>Returns the relevant weapon slot</returns>
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

    /// <summary>
    /// Checks to see if a given slot has a weapon
    /// </summary>
    /// <param name="i">Index for the slot we are checking</param>
    /// <returns>Whether or not the slot has the weapon</returns>
    public bool SlotHasWeapon(int i)
    {
        WeaponSlot weaponSlot = weaponSlots[i];
        if (weaponSlot.HasWeapon)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Resets all the category indexes to be zero
    /// </summary>
    public void ResetAllGunCategories()
    {
        foreach(GunCategories category in weaponCategories)
        {
            category.index = 0;
        }
    }

    /// <summary>
    /// Gets the relevant slot index from the slot category, this is used for weapon switching
    /// </summary>
    /// <param name="i">The slot index within the category</param>
    /// <returns>The index for the slot of the given category/</returns>
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

/// <summary>
/// This is a small class for each of the different gun categories (I.e how SMG and SHotgun are in the same category), this holds a list of weapon slots
/// </summary>
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
