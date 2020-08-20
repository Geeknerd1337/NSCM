using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using EZCameraShake;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{

    #region Private Members
    private Animator weaponAnimator;
    private CameraRollEffects rollEffects;
    private Camera playerCam;
    private FirstPersonController charController;
    private AudioSource weaponSound;
    #endregion

    #region Booleans
    private bool CanFire { get
        {
            return !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.fireAnimation) &&
                !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.aimFireAnimation) &&
                !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation) &&
                !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.aimDryFireAnimation) &&
                !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.dryFireAnimation);

        }
    }
    #endregion

    [Header("Weapon Object")]
    [SerializeField] private Weapon_SO weaponObject;

    [Header("Weapon Sway")]
    public float swayIntensity;
    public float smooth;
    [SerializeField]
    private Quaternion originRotation;

    [Header("Weapon Visual Effects")]
    [SerializeField] private ParticleSystem muzzleFlash;

    [Header("Weapon Stats")]
    private int shotsLeft;

    [Header("Event Systems")]
    [SerializeField] private UnityEvent fireEvents;



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
        //Set the origin rotation
        originRotation = transform.localRotation;
        //Get the Audio Source for the gun
        weaponSound = GetComponent<AudioSource>();
        //Set the number of shots left to the guns clip size
        shotsLeft = weaponObject.clipSize;

    }

    // Update is called once per frame
    void Update()
    {
        HandleGunInput();
        HandleWeaponSway();
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

        if (Input.GetButtonDown("Reload") && !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation))
        {
            weaponAnimator.Play(weaponObject.reloadAnimation);
            shotsLeft = weaponObject.clipSize;
            PlayWeaponSound(weaponObject.reloadSound);
        }
    }

    void FireGun()
    {
        if (CanFire)
        {
            //Play the fire animation if we press the fire button
            if (!weaponAnimator.GetBool("isAiming"))
            {
                if (shotsLeft > 0)
                {
                    weaponAnimator.Play(weaponObject.fireAnimation);
                    
                }
                else
                {
                    weaponAnimator.Play(weaponObject.dryFireAnimation);
                }
            }
            else
            {
                if (shotsLeft > 0)
                {
                    weaponAnimator.Play(weaponObject.aimFireAnimation);
                    
                }
                else
                {
                    weaponAnimator.Play(weaponObject.aimDryFireAnimation);
                }
            }

            #region Audio Effects
            if (shotsLeft > 0)
            {
                PlayWeaponSound(weaponObject.fireSound);
            }
            else
            {
                PlayWeaponSound(weaponObject.dryFireSound);
            }
            #endregion

            #region Visual Effects
            if (shotsLeft > 0)
            {
                //Shake the camera
                CameraShaker.Instance.Shake(CameraShakePresets.Shot);
                //Move the camera up a bit for some recoil
                charController.m_MouseLook_x += 2f;
                //Add a bit of a roll up that goes down over time, gives the recoild more flavor
                rollEffects.vectorAdditions.x += -5f;
                //Play the muzzle flash effect if it isn't null
                if (muzzleFlash != null)
                {
                    muzzleFlash.Play();
                }
                shotsLeft--;
            }
            #endregion

            fireEvents.Invoke();
        }
    }

    void HandleWeaponSway()
    {

        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        Quaternion adjustment = Quaternion.AngleAxis(swayIntensity * -1f * mouse_x, Vector3.up);
        Quaternion adjustmentY = Quaternion.AngleAxis(swayIntensity * 1f * mouse_y, Vector3.right);
        Quaternion targetRotation = originRotation * adjustment * adjustmentY;

        //transform.localPosition = Vector3.Lerp(transform.localPosition, idlePosition + new Vector3(Mathf.PerlinNoise(Time.time, Time.time) * idleAnim.x, Mathf.Sin(Time.time) * idleAnim.y, Mathf.PerlinNoise(Time.time, Time.time) * idleAnim.z), 10f * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, smooth * 10f * Time.deltaTime);
    }

    void PlayWeaponSound(WeaponSound w)
    {
        weaponSound.clip = w.sound;
        weaponSound.pitch = Random.Range(w.pitchRange.x, w.pitchRange.y);
        weaponSound.volume = w.volume;
        weaponSound.Play();
    }

}
