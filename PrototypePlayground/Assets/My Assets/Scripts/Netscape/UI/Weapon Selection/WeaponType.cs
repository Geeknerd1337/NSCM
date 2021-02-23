using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Weapon type is a UI element that essentially is the various categories of weapons. This is here so that we can hide and show the various categories as they're selected. I.e if you select the SMG, you seee the shotgun as well. 
/// </summary>
public class WeaponType : MonoBehaviour
{
    private RectTransform rt;
    /// <summary>
    /// A boolean value representing whether or not this category of weapons is opened
    /// </summary>
    public bool weaponsOpen;
    public Vector2 sizeDelta;
    
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsOpen)
        {
            if (rt.sizeDelta.x != sizeDelta.x)
            {
                rt.sizeDelta = new Vector2(sizeDelta.x, rt.sizeDelta.y);
            }
        }
        else
        {
            if(rt.sizeDelta.x != sizeDelta.y)
            {
                rt.sizeDelta = new Vector2(sizeDelta.y, rt.sizeDelta.y);
            }
        }
    }
}
