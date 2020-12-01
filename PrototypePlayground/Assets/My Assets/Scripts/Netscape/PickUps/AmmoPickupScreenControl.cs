using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScreenControl : MonoBehaviour
{

    public Renderer r;
    public int materialsIndex;
    private Material myMaterial;
    public Texture myTex;
    private float texOffset;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        myMaterial = r.materials[materialsIndex];
        myMaterial.SetTexture("_tex", myTex);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
