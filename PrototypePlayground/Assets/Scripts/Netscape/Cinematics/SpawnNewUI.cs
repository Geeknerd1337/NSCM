using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnNewUI : MonoBehaviour
{

    public Image i1;
    public GameObject i2;
    public GlitchEffectCinematic glitch;
    public AudioSource a;
    private bool trig;
    public Skybox sky;
    public Image i3;
    public Image i4;
    public GameObject level;
    public GameObject skipi;
    // Start is called before the first frame update
    void Start()
    {
        sky.enabled = false;
        i2.SetActive(false);
        i1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!trig)
            {
                i1.enabled = false;
                i2.SetActive(true);
                a.Play();
                glitch.Jump();
                trig = true;
                sky.enabled = true;
                i3.enabled = false;
                i4.enabled = false;
                level.SetActive(false);
                skipi.SetActive(false);
            }
        }
    }
}
