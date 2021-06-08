using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDecoDisc : MonoBehaviour
{

    private Vector3 initialScale;
    public float speed;
    public Weapon w;
    public Renderer r;
    [ColorUsageAttribute(true, true)]
    public Color c1;
    [ColorUsageAttribute(true, true)]
    public Color c2;
    public float colorSpeed;
    private float colorLerpAmt;
    private float colorLerpTar;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 modScale = initialScale;
        modScale.z *= w.ShotsLeft;
        transform.localScale = Vector3.Lerp(transform.localScale, modScale, speed * Time.deltaTime);
        if (w.IsReloading || w.ShotsLeft == 0)
        {
            transform.localScale = Vector3.zero;
        }
        ColorManage();
    }

    public void FireMe()
    {
        transform.localScale = Vector3.zero;
    }

    public void ColorManage()
    {
        colorLerpTar = 0;
        if (w.IsReloading || w.ShotsLeft == 0)
        {
            colorLerpTar = 1f;
        }
            r.materials[0].SetColor("_glowColor", Color.Lerp(c1, c2,colorLerpAmt));
        colorLerpAmt = Mathf.Lerp(colorLerpAmt, colorLerpTar, colorSpeed * Time.deltaTime);
    }
}
