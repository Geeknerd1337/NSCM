using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hackable : MonoBehaviour
{
    public float hackTimeMod = 1;
    public bool triggered;
    public bool canUse;
    public float coolDownTime;
    [SerializeField]
    private bool allowCooldown;

    public UnityEvent myEvents;

    public virtual void Interact()
    {
        if (allowCooldown)
        {
            StartCoroutine("CoolDown");
        }
        else
        {
            canUse = false;
        }
        myEvents.Invoke();
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
