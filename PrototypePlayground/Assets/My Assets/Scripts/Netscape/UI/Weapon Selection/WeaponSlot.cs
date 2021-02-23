using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A weapon slot is the small square representing the weapon on the UI, when selected, all the weapon slots in this category expand to show artwork of the relevant weapon
/// </summary>
public class WeaponSlot : MonoBehaviour
{  
    /// <summary>
    /// The weapon type of the slot
    /// </summary>
    [SerializeField]
    public WeaponType wt;

    /// <summary>
    /// The square image representing the unselected weapon
    /// </summary>
    [SerializeField]
    private Image slot;
    /// <summary>
    /// An image repesenting the weapon when expanded
    /// </summary>
    [SerializeField]
    private Image weapon;

    /// <summary>
    /// A rect tranform that changes size based on whether or not the weapon is selected, this is used in conjunction with a Unity grid layout to move other elements aside when this slot is selected.
    /// </summary>
    private RectTransform rt;
    /// <summary>
    /// The minimum and maximum size of the rect transform when selected and unselected
    /// </summary>
    public Vector2 sizeDelta;

    /// <summary>
    /// Whether or not this slot is selected
    /// </summary>
    public bool selected;

    /// <summary>
    /// The color for when this slot is selected
    /// </summary>
    public Color selectedCol;
    /// <summary>
    /// The color for when this slot is not selected
    /// </summary>
    public Color deselectedCol;
    /// <summary>
    /// A small nine sliced image that appears when this weapon is selected
    /// </summary>
    public Image selectedImage;
    /// <summary>
    /// The background image of the weapon
    /// </summary>
    public Image weaponBack;

    /// <summary>
    /// Boolean representing whether or not the player has this weapon.
    /// </summary>
    [SerializeField]
    private bool hasWeapon;

    public bool HasWeapon
    {
        get { return hasWeapon;  }
        set { hasWeapon = value; }
    }

    /// <summary>
    /// Enables the slot image
    /// </summary>
    public void EnableSlot()
    {
        slot.enabled = true;
    }

    /// <summary>
    /// The relevant gun index that maps to the same gun index on the weapon manager. Used for connecting a slot and weapon
    /// </summary>
    public int gunIndex;
    // Start is called before the first frame update
    void Start()
    {
        wt = GetComponentInParent<WeaponType>();
        rt = GetComponent<RectTransform>();
        selectedImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If we have this weapon and our weapon category is open
        if (wt.weaponsOpen && hasWeapon)
        {
            //If our slow is enabled, then disable it and enable the weapon image instead. This shows that we have this weapon
            if (slot.enabled)
            {
                slot.enabled = false;
                weapon.gameObject.SetActive(true);
            }
        }
        else
        {
            //If either of the above is false, and if the weapon image is enabled, then enable the slot image and disable the weapon image. Also check and see if we have the weapon to enable or disable the slot
            if (weapon.gameObject.activeSelf)
            {
                slot.enabled = true;
                weapon.gameObject.SetActive(false);
            }
            if (!hasWeapon)
            {
                slot.enabled = false;
            }
            else
            {
                slot.enabled = true;
            }
        }

        ChangeVertLayout();
        MakeChangesIfSelected();
    }

    /// <summary>
    /// Basically, if the weapons are open, change the size of our slot to match. Used for the grid layout
    /// </summary>
    void ChangeVertLayout()
    {
        if (wt.weaponsOpen)
        {
            
            if (rt.sizeDelta.y != sizeDelta.x)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, sizeDelta.x);
            }
        }
        else
        {
            if (rt.sizeDelta.y != sizeDelta.y)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, sizeDelta.y);
            }
        }
    }

    /// <summary>
    /// This function will change whether or not certain images and colors are enabled if this slot is selected. This includes changing the weapon color to the selected color and enabling the selected image. 
    /// </summary>
    void MakeChangesIfSelected()
    {
        if (selected)
        {
            weapon.color = new Vector4(selectedCol.r,selectedCol.g, selectedCol.b, weapon.color.a);
            weaponBack.color = selectedCol;
            selectedImage.enabled = true;
        }
        else
        {
            weapon.color = new Vector4(deselectedCol.r, deselectedCol.g, deselectedCol.b, weapon.color.a); ;
            weaponBack.color = deselectedCol;
            selectedImage.enabled = false;
        }
    }
}
