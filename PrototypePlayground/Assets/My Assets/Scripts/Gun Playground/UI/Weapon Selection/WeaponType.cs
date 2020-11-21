using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponType : MonoBehaviour
{
    private RectTransform rt;
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
