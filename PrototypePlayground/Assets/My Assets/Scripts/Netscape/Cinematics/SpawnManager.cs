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

    public GameObject friend;
    public AudioListener me;
    public AudioListener main;
    // Start is called before the first frame update
    void Start()
    {
        me.enabled = true;
        main.enabled = false;
        fps.enabled = false;
        spawnCamera.enabled = true;
        fpsCamera.enabled = false;
        friend.SetActive(false);
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
        me.enabled = false;
        main.enabled = true;

    }

    public void ActivateFriend()
    {
        friend.SetActive(true);
    }
}
