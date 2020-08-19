using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using EZCameraShake;

public class Weapon : MonoBehaviour
{

    #region Private Members
    private Animator weaponAnimator;
    private CameraRollEffects rollEffects;
    private Camera playerCam;
    private FirstPersonController charController;
    #endregion

    [Header("Weapon Object")]
    [SerializeField] private Weapon_SO weaponObject;


    

    // Start is called before the first frame update
    void Start()
    {
        //Get the weapon's Animator
        weaponAnimator = GetComponent<Animator>();
        //Find the roll Effects
        rollEffects = FindObjectOfType<CameraRollEffects>();
        //Get the main camera
        playerCam = Camera.main;
        //Get the first person controller
        charController = FindObjectOfType<FirstPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        HandleGunInput();
    }

    private void LateUpdate()
    {
        playerCam.transform.localEulerAngles += new Vector3(10f, 0, 0);
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
            CameraShaker.Instance.Shake(CameraShakePresets.Shot);
            charController.m_MouseLook_x += 2f;
            rollEffects.vectorAdditions.x += -5f;
        }
    }

}
