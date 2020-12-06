using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{
    public Renderer render;
    public float animSpeed;
    public int materialIndex;
    public Vector2 glitchValues;

    public Texture t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        render.materials[materialIndex].SetFloat("_glitchAmt", Mathf.Lerp(glitchValues.x, glitchValues.y, Mathf.PerlinNoise(animSpeed * Time.deltaTime, 0)));
     }

    public void Die()
    {
        render.materials[materialIndex].SetTexture("_tex", t);
    }
}
