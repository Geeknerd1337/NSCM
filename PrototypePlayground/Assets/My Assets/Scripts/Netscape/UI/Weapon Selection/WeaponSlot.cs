using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{  
    [SerializeField]
    public WeaponType wt;

    [SerializeField]
    private Image slot;
    [SerializeField]
    private Image weapon;

    private RectTransform rt;
    public Vector2 sizeDelta;

    public bool selected;
    public Color selectedCol;
    public Color deselectedCol;
    public Image selectedImage;
    public Image weaponBack;

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
        if (wt.weaponsOpen)
        {
            if (slot.enabled)
            {
                slot.enabled = false;
                weapon.gameObject.SetActive(true);
            }
        }
        else
        {
            if (weapon.gameObject.activeSelf)
            {
                slot.enabled = true;
                weapon.gameObject.SetActive(false);
            }
        }

        ChangeVertLayout();
        MakeChangesIfSelected();
    }

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
