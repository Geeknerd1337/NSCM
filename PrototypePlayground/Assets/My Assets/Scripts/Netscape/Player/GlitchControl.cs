using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;
public class GlitchControl : MonoBehaviour
{

    public DigitalGlitch[] glitches;
    [Range(0, 1)]
    public float amt = 0;
    // Start is called before the first frame update
    void Start()
    {
        glitches = GetComponentsInChildren<DigitalGlitch>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DigitalGlitch g in glitches)
        {
            g.intensity = amt;
        }
    }
}
