using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchEffectCinematic : MonoBehaviour
{
    public DigitalGlitch digi;
    public float glitchTar;
    public float glitchSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        digi.intensity = Mathf.Lerp(digi.intensity, glitchTar, glitchSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        digi.intensity = 1f;
    }
}
