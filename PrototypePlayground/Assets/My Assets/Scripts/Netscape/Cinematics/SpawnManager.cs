using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class SpawnManager : MonoBehaviour
{

    public FirstPersonController fps;
    public Camera fpsCamera;
    public Camera spawnCamera;
    public AudioSource a;
    public GameObject g;

    public Animator a2;
    public AudioSource a3;
    public float delay;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        fps.enabled = false;
        spawnCamera.enabled = true;
        fpsCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0 && !played) {
            a2.Play("Introduction");
            a3.Play();
            played = true;

        }
    }

    public void SpawnPlayer()
    {
        fps.enabled = true;
        a.Play();
        fpsCamera.enabled = true;
        spawnCamera.enabled = false;
        g.SetActive(false);
        
    }
}
