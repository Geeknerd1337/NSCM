using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GattlingTurret : MonoBehaviour
{

    /// <summary>
    /// Reference to the player object
    /// </summary>
    private CyberSpaceFirstPerson player;

    /// <summary>
    /// The 'body' of the turret
    /// </summary>
    [SerializeField]
    private Transform turret;

    /// <summary>
    /// The speed at which the turret rotates toward the player
    /// </summary>
    [SerializeField]
    private float turretSpeed;

    /// <summary>
    /// A vector 2 for clamping the rotation of the object
    /// </summary>
    [SerializeField]
    private Vector2 turretRotClamp;

    /// <summary>
    /// The transform representing the pivot for the gatling gun
    /// </summary>
    [SerializeField]
    private Transform gattlingPivot;

    /// <summary>
    /// The speed at which the gattling rotates toward the player
    /// </summary>
    [SerializeField]
    private float gattlingSpeed;

    /// <summary>
    /// Vector 2 for if we want to clamp the pivot
    /// </summary>
    [SerializeField]
    private Vector2 pivotRotClamp;


    /// <summary>
    /// The place where the "eyes" of the turret shoot from
    /// </summary>
    [SerializeField] private Transform eyes;

    /// <summary>
    /// Whether or not the turret is alerted
    /// </summary>
    private bool alerted;

    /// <summary>
    /// Amount of time it takes to spin up the barrel, essentially
    /// </summary>
    [SerializeField] private float alertTime;
    private float alertTimer;

    /// <summary>
    /// The time it takes for a turret to give up
    /// </summary>
    ///
    [SerializeField] private float giveUpTime;
    private float giveUpTimer;

    [Header("Weapon Firing")]
    /// <summary>
    /// The amount of time in between each shot
    /// </summary>
    [SerializeField] private float fireTime;
    private float fireTimer;

    /// <summary>
    /// An event system for firing the weapon
    /// </summary>
    [SerializeField] private UnityEvent fireEvents;


    /// <summary>
    /// The accuracy of the turret, baiscally
    /// </summary>
    [SerializeField] private float fireAngle;

    /// <summary>
    /// The range of the turret
    /// </summary>
    [SerializeField] private float fireRange;

    /// <summary>
    /// The damage the turret does
    /// </summary>
    /// 
    [SerializeField] private float turretDamage;


    /// <summary>
    /// A transform for the barrel
    /// </summary>
    /// 
    [SerializeField] private Transform barrelEnd;


    [Header("Weapon Effects")]
    /// <summary>
    /// Curve for the spinning up of the barrel
    /// </summary>
    [SerializeField] private AnimationCurve spinCurve;

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
    /// A reference to the effect spawned by a buller
    /// TODO: Convert this to a pooled particle system
    /// </summary>
    [SerializeField] private GameObject hitEffect;

    /// <summary>
    /// The audio source for the various beeps the turrets make
    /// </summary>
    [Header("Audio")]
    [SerializeField] private AudioSource turretBeeps;
    /// <summary>
    /// The audio source for things like the barrel spin and the firing of the weapon
    /// </summary>
    [SerializeField] private AudioSource turretGun;

    /// <summary>
    /// The spin of the barrel
    /// </summary>
    [SerializeField] private AudioClip barrelSpin;

    /// <summary>
    /// The sound of the turret firing
    /// </summary>
    [SerializeField] private AudioClip turretFire;

    /// <summary>
    /// The sound of the turret being alerted
    /// </summary>
    [SerializeField] private AudioClip turretAlert;

    /// <summary>
    /// The clip for the turret beeping
    /// </summary>
    [SerializeField] private AudioClip turretBeep;

    /// <summary>
    /// The clip for the turret spinning down
    /// </summary>
    [SerializeField] private AudioClip turretSpinDown;

    private float beepTimer;
    /// <summary>
    /// The time in between each beep
    /// </summary>
    [SerializeField]
    private float beepTime;


    [SerializeField]
    private Vector3 debugVector3;

    /// <summary>
    /// Reference to the barrel transform
    /// </summary>
    [Header("Barrel")]
    [SerializeField] private Transform barrel;

    /// <summary>
    /// The max rotation speed of the barrel
    /// </summary>
    [SerializeField] private float maxBarrelSpeed;

    /// <summary>
    /// Prefab representing the lasers
    /// </summary>
    [Header("Lasers")]
    [SerializeField] private GameObject laserPrefab;
    /// <summary>
    /// The numbers of lasers t ofire
    /// </summary>
    [SerializeField] private int numLasers;
    /// <summary>
    /// A private list of the line renderers that make up the lasers
    /// </summary>
    private List<LineRenderer> lasers = new List<LineRenderer>();
    /// <summary>
    /// The range of the lasers
    /// </summary>
    [SerializeField] private float laserRange;

    /// <summary>
    /// Layer mask for the lasers
    /// </summary>
    [SerializeField] private LayerMask laserMask;

    /// <summary>
    /// The origin for the lasers
    /// </summary>
    [SerializeField] private Transform laserOrigin;

    /// <summary>
    /// The max angle the lasers can be at
    /// </summary>
    [SerializeField]
    [Range(0, 1)]
    private float laserAngle;


    /// <summary>
    /// Whether or not to even use the lasers
    /// </summary>
    [SerializeField] private bool userLasers;


    // Start is called before the first frame update
    void Start()
    {
        //Assigning the player
        player = FindObjectOfType<CyberSpaceFirstPerson>();
        //Create the lasers and add them to the list
        CreateLasers();
        //Initiates the array that will hold our pooled particle tracers
        tracerParticles = new ParticleSystem.Particle[tracerSystem.main.maxParticles];


    }

    // Update is called once per frame
    void Update()
    {
        if (alerted)
        {
            RotateTurretTowardsPlayer();
            RotateGattlerTowardsPlayer();

            alertTimer += Time.deltaTime;
            RotateBarrel(spinCurve.Evaluate( Mathf.Clamp01(alertTimer / alertTime)));

            if(alertTimer > alertTime)
            {
                if (!turretGun.isPlaying)
                {
                    turretGun.clip = turretFire;
                    turretGun.loop = true;
                    turretGun.Play();
                }

                fireTimer += Time.deltaTime;
                if(fireTimer > fireTime)
                {
                    fireTimer = 0;
                    fireEvents.Invoke();
                    FireRayBullet();
                }

            }

        }
        else
        {
            beepTimer += Time.deltaTime;
            if(beepTimer > beepTime)
            {
                beepTimer = 0;
                turretBeeps.PlayOneShot(turretBeep);
            }
        }



        CheckAlert();
        //ConeLaser();
    }

    /// <summary>
    /// Fires a 'Ray' bullet using a Unity raycast. In layman's terms, this is a hitscan bullet.
    /// </summary>
    void FireRayBullet()
    {
            RaycastHit hit;

            //This handles the fire spread and is kind of black magic
            float splash = fireAngle;
            Vector3 direction = Random.insideUnitSphere * Mathf.Lerp(0, 1, fireAngle / 180f);
            Vector3 directionActual = barrelEnd.transform.forward + direction;

            //Checks to see if we've hit an enemy limb, and damaged it if we have
            if (Physics.Raycast(barrelEnd.transform.position, directionActual, out hit, fireRange, laserMask))
            {
                GameObject g = Instantiate(hitEffect);
                g.transform.position = hit.point;
                g.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                g.transform.parent = hit.transform;
                Destroy(g, 10f);


                EntityLimb entityLimb = hit.collider.GetComponent<EntityLimb>();
                if (entityLimb != null)
                {

                    entityLimb.DamageEnemy(turretDamage, transform.forward);

                }

                PlayerStats ps = hit.collider.GetComponent<PlayerStats>();
                if(ps != null)
                {
                ps.DamagePlayer(turretDamage, transform.position);
                }
            }


           CreateTracer(tracerSystem.transform.position, directionActual);

    }

    void RotateBarrel(float f)
    {
        float val = barrel.localEulerAngles.z - maxBarrelSpeed * Time.deltaTime * f;
        barrel.localEulerAngles = new Vector3(180, 0, val);
    }

    

    void CreateLasers()
    {
        //Create each laser and add its line renderer to the list
        for(int i = 0; i < numLasers; i++)
        {
            GameObject g = Instantiate(laserPrefab);
            g.transform.SetParent(laserOrigin);
            LineRenderer lr = g.GetComponent<LineRenderer>();
            if (lr != null)
            {
                lasers.Add(lr);
                if (!userLasers)
                {
                    lasers[i].enabled = false;
                }
            }
        }
    }

    void RotateTurretTowardsPlayer()
    {
        Vector3 direction = player.transform.position - turret.transform.position;
        
        // calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(turret.rotation, Quaternion.LookRotation(direction, transform.up), turretSpeed * Time.deltaTime);

        //Apply the rotation 
        turret.rotation = rot;

        turret.localEulerAngles = new Vector3(0, turret.localEulerAngles.y, 0);
    }

    void RotateGattlerTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - Vector3.up) - turret.transform.position;

        // calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(gattlingPivot.rotation, Quaternion.LookRotation(direction, transform.up), gattlingSpeed * Time.deltaTime);

        //Apply the rotation 
        gattlingPivot.rotation = rot;

        float rotX = gattlingPivot.localEulerAngles.x;

        if(rotX > 180 && rotX < pivotRotClamp.y)
        {
            rotX = pivotRotClamp.y;
        }

        if(rotX < 180 && rotX > pivotRotClamp.x)
        {
            rotX = pivotRotClamp.x;
        }

        

        gattlingPivot.localEulerAngles = new Vector3(rotX, 0, 0);
        debugVector3 = gattlingPivot.localEulerAngles;
    }

    void CheckAlert()
    {
        Vector3 direction = player.transform.position - eyes.transform.position;
        
        RaycastHit hit;
        bool raycast = Physics.Raycast(eyes.transform.position, direction.normalized, out hit, laserRange, laserMask);

        if (alerted)
        {
            if ((raycast && hit.collider.tag == "Player"))
            {
                giveUpTimer = 0;
            }

            if (!raycast || (raycast && hit.collider.tag != "Player"))
            {
                giveUpTimer += Time.deltaTime;
                if (giveUpTimer > giveUpTime)
                {
                    giveUpTimer = 0;
                    alertTimer = 0;
                    alerted = false;
                    turretGun.Stop();
                    turretGun.loop = false;
                    turretGun.PlayOneShot(turretSpinDown);
                }

            }
        }

        if (raycast && !alerted)
        {
            if (hit.collider.tag == "Player")
            {
                float dot = Vector3.Dot(direction, eyes.forward);
                if (dot > 0.75)
                {
                    alerted = true;
                    turretGun.PlayOneShot(barrelSpin);
                    turretBeeps.clip = turretAlert;
                    turretBeeps.Play();
                }
            }
        }
    }

    void ShootLaser(Vector3 origin, Vector3 direction, LineRenderer r)
    {
        RaycastHit hit;
        bool raycast = Physics.Raycast(origin, direction,out hit, laserRange, laserMask);

        if(r != null)
        {
            r.SetPosition(0, origin);
            
        }

        if (raycast)
        {
            r.SetPosition(1, hit.point);
        }
        else
        {
            r.SetPosition(1, origin + direction * laserRange);
        }
    }

    void ConeLaser()
    {
        for(int i = 0; i < numLasers; i++)
        {
            if(i == 0)
            {
                ShootLaser(laserOrigin.position, laserOrigin.forward, lasers[i]);
            }
            else
            {
                float value = (i + 1) / (float)(numLasers - 1);
                float angle = (Mathf.PI * 2) * value;
                Vector3 direction = laserOrigin.forward + laserAngle * laserOrigin.up * Mathf.Sin(angle) + laserAngle * laserOrigin.right * Mathf.Cos(angle);
                ShootLaser(laserOrigin.position, direction, lasers[i]);
            }

            
        }
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
        emitParams.rotation3D = direction + new Vector3(0, 90f, 0);
        tracerSystem.Emit(emitParams, 1);

    }

}
