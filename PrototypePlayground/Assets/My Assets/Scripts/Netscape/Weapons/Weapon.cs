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
    [SerializeField]
    private Camera playerCam;
    [SerializeField]
    private Camera weaponCam;
    private CyberSpaceFirstPerson charController;
    private AudioSource weaponSound;
    private PlayerStats playerStats;
    #endregion

    #region Booleans
    private bool CanFire { get
        {

           return !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.fireAnimation) &&
           !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.aimFireAnimation) &&
           !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation) &&
           !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.aimDryFireAnimation) &&
           !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.dryFireAnimation) &&
           !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.drawAnimation);

        }
    }

    private bool isBusy;

    public bool IsReloading { get { return weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation); } }
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
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform projectileOrigin;

    [Header("Weapon Stats")]
    private int shotsLeft;
    public int ShotsLeft
    {
        get { return shotsLeft; }
        set { shotsLeft = value; }
    }
    public int AmmoType
    {
        get { return ammoType; }
    }
    [SerializeField]
    private int ammoType;

    [Header("Raycast Fire Setup")]
    [SerializeField] private LayerMask bulletLayerMask;

    [Header("Event Systems")]
    [SerializeField] private UnityEvent fireEvents;

    [Header("Weapon Toggles")]
    [SerializeField] private bool allowAim;
    [SerializeField] private bool fullAuto;
    [SerializeField] private bool zoomOnAim;
    [SerializeField] private bool smoothAimTrans;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private Vector2 minMaxFOV;
    private LevelSaveDataController settings;


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
        charController = FindObjectOfType<CyberSpaceFirstPerson>();
        //Set the origin rotation
        originRotation = transform.localRotation;
        //Get the Audio Source for the gun
        weaponSound = GetComponent<AudioSource>();
        //Set the number of shots left to the guns clip size
        shotsLeft = weaponObject.clipSize;
        //Get the player stats so we can handle ammo
        playerStats = GetComponentInParent<PlayerStats>();
        //Plays the draw animation on start
        weaponAnimator.Play(weaponObject.drawAnimation);
        //This is so we can use the FOV slider
        //This goes in awake since the settings menu is usually deactivated
        settings = FindObjectOfType<LevelSaveDataController>();


    }


    // Update is called once per frame
    void Update()
    {
        if (MenuPause.GamePaused)
        {
            return;
        }
        HandleGunInput();
        HandleWeaponSway();
        HandleFOV();
    }

    private void LateUpdate()
    {
        
    }

    void HandleGunInput()
    {

        bool IsFiring = Input.GetButtonDown("Fire1");
        if (fullAuto)
        {
            IsFiring = Input.GetButton("Fire1");
        }
        if (IsFiring)
        {
            FireGun();
        }

        if (Input.GetButtonDown("Fire2") && allowAim)
        {
            //Toggle the aim animation
            weaponAnimator.SetBool("isAiming", !weaponAnimator.GetBool("isAiming"));
        }

        if (Input.GetButtonDown("Reload") && !weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation))
        {

            if (shotsLeft < weaponObject.clipSize && playerStats.ammoTypes[ammoType] != 0)
            {
                weaponAnimator.Play(weaponObject.reloadAnimation);
                PlayWeaponSound(weaponObject.reloadSound);
                if (playerStats.ammoTypes[ammoType] >= (weaponObject.clipSize - shotsLeft))
                {
                    playerStats.ammoTypes[ammoType] -= (weaponObject.clipSize - shotsLeft);
                    shotsLeft = weaponObject.clipSize;

                }
                else
                {
                    playerStats.ammoTypes[ammoType] = 0;
                    shotsLeft = weaponObject.clipSize;
                }
            }
        }
    }

    void FireGun()
    {
        if (CanFire && !isBusy)
        {
            //Play the fire animation if we press the fire button
            if (!weaponAnimator.GetBool("isAiming"))
            {
                if (shotsLeft > 0)
                {
                    weaponAnimator.Play(weaponObject.fireAnimation);
                    //Fire a projectile if the weapon is configured to do so, otherwise use raycast bullet
                    if (weaponObject.firesProjectile)
                    {
                        FireProjectile();
                    }
                    else
                    {
                        FireRayBullet();
                    }
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
                    //Fire a projectile if the weapon is configured to do so, otherwise use raycast bullet
                    if (weaponObject.firesProjectile)
                    {
                        FireProjectile();
                    }
                    else
                    {
                        FireRayBullet();
                    }

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
                CameraShakeInstance c = new CameraShakeInstance(0.5f, 20, 0f, 0.5f);
                c.PositionInfluence = Vector3.one * 1f * weaponObject.shakeAmmount;
                c.RotationInfluence = new Vector3(4, 1, 1) * weaponObject.shakeAmmount;
                CameraShaker.Instance.Shake(c);
                //Move the camera up a bit for some recoil
                charController.m_MouseLook_x += weaponObject.recoil;
                //Add a bit of a roll up that goes down over time, gives the recoild more flavor
                rollEffects.vectorAdditions.x += weaponObject.recoil * -2.5f;
                //Play the muzzle flash effect if it isn't null
                if (muzzleFlash != null)
                {
                    muzzleFlash.Play();
                }
                shotsLeft--;
            }
            #endregion

            //Invokes the event list for when the gun is fired, use this for more non-universal gun properties
            fireEvents.Invoke();
            
        }
    }

    void FireRayBullet()
    {
        for(int i = 0; i < weaponObject.numberOfShots; i++)
        {
            RaycastHit hit;

            //This handles the fire spread and is kind of black magic
            float splash = weaponObject.maxFireAngle;
            Vector3 direction = Random.insideUnitSphere * Mathf.Lerp(0,1,weaponObject.maxFireAngle/180f);
            Vector3 directionActual = transform.forward + direction;

            //Checks to see if we've hit an enemy limb, and damaged it if we have
            if (Physics.Raycast(playerCam.transform.position, directionActual, out hit, weaponObject.effectiveRange, bulletLayerMask))
            {
                GameObject g = Instantiate(hitEffect);
                g.transform.position = hit.point;
                g.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                g.transform.parent = hit.transform;
                Destroy(g, 10f);
                

                EntityLimb entityLimb = hit.collider.GetComponent<EntityLimb>();
                if(entityLimb != null)
                {
                    entityLimb.DamageEnemy(weaponObject.damage, transform.forward);
                }
            }
        }
    }

    void FireProjectile()
    {
        //This handles the fire spread and is kind of black magic
        float splash = weaponObject.maxFireAngle;
        Vector3 direction = Random.insideUnitSphere * Mathf.Lerp(0, 1, weaponObject.maxFireAngle / 180f);
        Vector3 directionActual = transform.forward + direction;

        //Instantiate the projectile
        GameObject projectile = Instantiate(weaponObject.projectilePrefab);
        //Set its forward rotation to that of the cameras plus the direction actual
        projectile.transform.rotation = Quaternion.LookRotation(directionActual);
        //Set the position of the projectile to the designated position
        projectile.transform.position = projectileOrigin.position;
    }

    public static Vector3 RandomInsideCone(float radius)
    {
        //(sqrt(1 - z^2) * cosϕ, sqrt(1 - z^2) * sinϕ, z)
        float radradius = radius * Mathf.PI / 360;
        float z = Random.Range(Mathf.Cos(radradius), 1);
        float t = Random.Range(0, Mathf.PI * 2);
        return new Vector3(Mathf.Sqrt(1 - z * z) * Mathf.Cos(t), Mathf.Sqrt(1 - z * z) * Mathf.Sin(t), z);
    }

    float CalculateFireAngle(float f) {
        float sign = Mathf.Sign(f) * 1;
        float amt = Mathf.Abs(f);
        float amtActual = Mathf.Lerp(0, (1 / 360f) * weaponObject.maxFireAngle, amt);
        Debug.Log(amtActual * sign);
        return (amt / weaponObject.maxFireAngle) * sign;


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
        weaponSound.PlayOneShot(weaponSound.clip);
    }

    private void OnEnable()
    {
        if(weaponAnimator != null)
        {
            weaponAnimator.Play(weaponObject.drawAnimation);
        }
    }


    void HandleFOV()
    {
        if (zoomOnAim)
        {
            float val = minMaxFOV.x + SaveLoadSettingManager.FOV;
            if (weaponAnimator.GetBool("isAiming"))
            {
                val = minMaxFOV.y;
            }
            if (smoothAimTrans)
            {

                playerCam.fieldOfView = Mathf.MoveTowards(playerCam.fieldOfView, val, zoomSpeed * Time.deltaTime);

                

            }
            else
            {
                weaponCam.fieldOfView = val;
                playerCam.fieldOfView = val;
            }
        }
        else
        {
            
            weaponCam.fieldOfView = minMaxFOV.x;
            playerCam.fieldOfView = minMaxFOV.x + SaveLoadSettingManager.FOV;
            
        }
    }


}
