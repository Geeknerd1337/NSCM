using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOutLights : MonoBehaviour
{
    public Renderer r;
    public int matIndex;
    public string property;
    public float targetIntensity;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillTheLights()
    {
        Material m = r.materials[matIndex];
        Color c = m.GetColor(property);
        m.SetColor(property, c * targetIntensity);
    }
}
