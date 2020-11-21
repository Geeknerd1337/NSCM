using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackable : MonoBehaviour
{
    public float hackTimeMod = 1;
    public bool triggered;
    public bool canUse;
    public float coolDownTime; 
    public virtual void Interact()
    {
        StartCoroutine("CoolDown");
    }

    private void Start()
    {
        canUse = true;
    }

    public IEnumerator CoolDown()
    {
        canUse = false;
        yield return new WaitForSeconds(coolDownTime);
        canUse = true;
    }
}
