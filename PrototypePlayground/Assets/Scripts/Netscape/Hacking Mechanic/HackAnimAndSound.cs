using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackAnimAndSound : Hackable
{

    public Animator a;
    public AudioClip clip;
    public AudioSource sound;
    public string anim;
    public override void Interact()
    {
        base.Interact();
        a.Play(anim);
        sound.PlayOneShot(clip);
    }
}
