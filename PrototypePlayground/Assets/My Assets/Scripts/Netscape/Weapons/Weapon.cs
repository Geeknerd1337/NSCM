using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using EZCameraShake;
using UnityEngine.Events;

/// <summary>
/// This class handles the guns in the game. It is powered using a Scriptable Object and handles the animations, stats, and firing of the weapon.
/// </summary>
public class Weapon : MonoBehaviour
{

    #region Private Members
    /// <summary>
    /// Reference to the weapons animator component.
    /// </summary>
    private Animator weaponAnimator;
    /// <summary>
    /// Reference to the cameras roll effects
    /// </summary>
    private CameraRollEffects rollEffects;
    /// <summary>
    /// A reference to the players camera
    /// </summary>
    [SerializeField]
    private Camera playerCam;
    /// <summary>
    /// A reference to the view model camera. Rendered on a seperate layer above everything else so the weapon doesn't clip through world geometry.
    /// </summary>
    [SerializeField]
    private Camera weaponCam;

    /// <summary>
    /// A reference to the character controller
    /// </summary>
    private CyberSpaceFirstPerson charController;
    /// <summary>
    /// A reference to the audio source from which all weapon sounds are made. 
    /// </summary>
    private AudioSource weaponSound;
    /// <summary>
    /// A reference to the player stats class.
    /// </summary>
    private PlayerStats playerStats;
    #endregion

    #region Booleans
    /// <summary>
    /// A boolean representing whether or not the weapon can fire. This is based on the various animations listed in the weapon object scriptable object. This is used to give information on whether
    /// any of the listed animations are playing.
    /// 
    /// </summary>
    /// <listheader>Animations That Prevent Firing</listheader>
    /// <list type="number">
    /// <item>Fire Animation</item>
    /// <item>Aim Fire Animationn</item>
    /// <item>Reload Animation</item>
    /// <item>Aim Dry Fire Animationn</item>
    /// <item>Draw Animation</item>
    /// <item>Dry Fire Animation</item>
    /// </list>
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

    /// <summary>
    /// A boolean that checks if the animators reload animation is playing. Used to check if the player is reloading
    /// </summary>
    public bool IsReloading { get { return weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName(weaponObject.reloadAnimation); } }
    #endregion

    /// <summary>
    /// A reference to the scriptable object that provides all the data on the individual weapons stats.
    /// </summary>
    [Header("Weapon Object")]
    [SerializeField] private Weapon_SO weaponObject;

    /// <summary>
    /// The intensity of the weapons 'sway'
    /// </summary>
    [Header("Weapon Sway")]
    public float swayIntensity;
    /// <summary>
    /// The smoothing value for the weapon sway. Higher values will result in a 'slower' sway.
    /// </summary>
    public float smooth;
    /// <summary>
    /// This is a value that holds the original rotation of the weapon. This is used to determine what value the sway needs to smooth to. 
    /// </summary>
    [SerializeField]
    private Quaternion originRotation;

    /// <summary>
    /// A reference to the muzzle flash particle system
    /// </summary>
    [Header("Weapon Visual Effects")]
    [SerializeField] private ParticleSystem muzzleFlash;
    /// <summary>
    /// A reference to the effect spawned by a buller
    /// TODO: Convert this to a pooled particle system
    /// </summary>
    [SerializeField] private GameObject hitEffect;

    /// <summary>
    /// A reference to a particle system that we move around and emit when we hit an enemy. This will make for some decent blood spatter
    /// </summary>
    [SerializeField] private ParticleSystem bloodEffect;

    /// <summary>
    /// If the weapon fires projectiles, this is a transform holding the position where the projectile is spawned. 
    /// </summary>
    [SerializeField] private Transform projectileOrigin;

    /// <summary>
    /// A reference to a particle system for the tracers
    /// </summary>
    [SerializeField]
    private ParticleSystem tracerSystem;
    /// <summary>
    /// The max number of tracers allowed at a time
    /// </summary>
    [SerializeField]
    private float maxTracers;

    /// <summary>
    /// A reference to the actual particles of the tracer particle system
    /// </summary>
    private ParticleSystem.Particle[] tracerParticles;
    /// <summary>
    /// Emit parameters for a particle
    /// </summary>
    private ParticleSystem.EmitParams emitParams;
    private int lastParticleIndex = 0;

    /// <summary>
    /// The number of shts left in a weapon
    /// </summary>
    [Header("Weapon Stats")]
    private int shotsLeft;
    /// <summary>
    /// Public reference to shotsLeft.
    /// </summary>
    public int ShotsLeft
    {
        get { return shotsLeft; }
        set { shotsLeft = value; }
    }
    /// <summary>
    /// Public reference to ammo type.
    /// </summary>
    public int AmmoType
    {
        get { return ammoType; }
    }
    /// <summary>
    /// A variable holding which 'type' of ammo our weapon uses.
    /// </summary>
    [SerializeField]
    private int ammoType;

    /// <summary>
    /// A layer mask for the bullets
    /// </summary>
    [Header("Raycast Fire Setup")]
    [SerializeField] private LayerMask bulletLayerMask;


    /// <summary>
    /// A Unity Event for when we fire the weapon
    /// </summary>
    [Header("Event Systems")]
    [SerializeField] private UnityEvent fireEvents;

    /// <summary>
    /// Allows us to Aim the weapon
    /// </summary>
    [Header("Weapon Toggles")]
    [SerializeField] private bool allowAim;
    /// <summary>
    /// A boolean determining whether or not a weapon is fully automatic
    /// </summary>
    [SerializeField] private bool fullAuto;
    /// <summary>
    /// A boolean representing whether or not we want to zoom in when we aim the weapon
    /// </summary>
    [SerializeField] private bool zoomOnAim;
    /// <summary>
    /// A boolean representing whether or not we want to smoothly transition to the zoom when we aim
    /// </summary>
    [SerializeField] private bool smoothAimTrans;
    /// <summary>
    /// The speed at which we zoom
    /// </summary>
    [SerializeField] private float zoomSpeed;
    /// <summary>
    /// The min and max FOV determining our zoomed and unzoomed FOV
    /// TODO: Convert this to a global
    /// </summary>
    [SerializeField] private Vector2 minMaxFOV;
    /// <summary>
    /// A boolean representing whether or not this weapon creates tracers
    /// </summary>
    [SerializeField] private bool useTracers;

    /// <summary>
    /// A private reference to our settings
    /// </summary>
    private LevelSaveDataController settings;

    [SerializeField] private bool autoreloadIfEmpty = true;


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
        //Initiates the array that will hold our pooled particle tracers
        tracerParticles = new ParticleSystem.Particle[tracerSystem.main.maxParticles];

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
        if (autoreloadIfEmpty && shotsLeft == 0)
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

    private void LateUpdate()
    {
        
    }


    /// <summary>
    /// This function is what handles the input for our weapons. This controls things like firing the weapon, aiming the weapon, and reloading the weapon.
    /// </summary>
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
		
		bool b = true;
		b = !b;
		//Set b to be false;
		

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
                weaponAnimator.SetBool("isAiming", false);
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


    /// <summary>
    /// This is a function called when the weapon is fired. If the weapon can be fired, then the weapon will fire either a projectile or a ray bullet
    /// based on the firesProjectile property on weaponObject. In adition to this, it will play the relevant audio for the sound, also based on a property in the weapon object.
    /// This function also handles visual effects like the muzzle flash and camera shake. 
    /// </summary>
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


    /// <summary>
    /// Fires a 'Ray' bullet using a Unity raycast. In layman's terms, this is a hitscan bullet.
    /// </summary>
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
                    bloodEffect.transform.position = hit.point;
                    bloodEffect.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    bloodEffect.Play();
                    entityLimb.DamageEnemy(weaponObject.damage, transform.forward);

                }
            }

            if (useTracers)
            {
                CreateTracer(tracerSystem.transform.position, directionActual);
            }
        }
    }


    /// <summary>
    /// Fires a projectile instead of a ray bullet. Will spawn the projectile at the projectileOrigin position.
    /// </summary>
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

    /// <summary>
    /// Handles the weapon sway by adjusting the rotation based on the input from the mouse X and Y axis.
    /// </summary>
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

    /// <summary>
    /// Plays the relevant weapon sound from the WeaponSound class.
    /// </summary>
    /// <param name="w">The WeaponSound object we are passing in in order to play a sound</param>
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

    /// <summary>
    /// Thhis is what handles the FOV of the camera. Takes into account the SaveLoadSettingsManager FOV value
    /// TODO: Move more aspects of this to a global scope.
    /// </summary>
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

    /// <summary>
    /// Temporarily prevents the user from firing. Used when selecting weapons
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitToAllowFire()
    {
        isBusy = true;
        float i = 0;
        while(i < 0.05)
        {
            i += Time.deltaTime;
            yield return null;
        }
        isBusy = false;
        Debug.Log("Success");
    }


    /// <summary>
    /// Creates a tracer on the tracerParticles particle system at a given location and in a given direction
    /// </summary>
    /// <param name="position">The position of the tracer</param>
    /// <param name="direction">The direction of the tracer</param>
    void CreateTracer(Vector3 position, Vector3 direction)
    {
        int activeParticles = tracerSystem.GetParticles(tracerParticles);

        if (activeParticles >= tracerSystem.main.maxParticles)
        {
            tracerParticles[lastParticleIndex].remainingLifetime = -1;

            if (lastParticleIndex >= maxTracers)
            {
                lastParticleIndex = 0;
            }

            tracerSystem.SetParticles(tracerParticles, tracerParticles.Length);
        }

        emitParams.position = position;
        emitParams.velocity = direction * 60f;
        emitParams.rotation3D = direction + new Vector3(0,90f,0);
        tracerSystem.Emit(emitParams, 1);

    }


}
