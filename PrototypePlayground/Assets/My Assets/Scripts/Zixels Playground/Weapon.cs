using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    #region Private Members
    private Animator weaponAnimator;
    #endregion

    [Header("Weapon Object")]
    [SerializeField] private Weapon_SO weaponObject;


    

    // Start is called before the first frame update
    void Start()
    {
        //Get the weapon's Animator
        weaponAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleGunInput();
    }

    void HandleGunInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireGun();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //Toggle the aim animation
            weaponAnimator.SetBool("isAiming", !weaponAnimator.GetBool("isAiming"));
        }

        if (Input.GetButtonDown("Reload"))
        {
            weaponAnimator.Play(weaponObject.reloadAnimation);
        }
    }

    void FireGun()
    {
        if (!weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.fireAnimation) && !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.fireAnimation))
        {
            //Play the fire animation if we press the fire button
            if (!weaponAnimator.GetBool("isAiming"))
            {
                weaponAnimator.Play(weaponObject.fireAnimation);
            }
            else
            {
                weaponAnimator.Play(weaponObject.aimFireAnimation);
            }
        }
    }

}
