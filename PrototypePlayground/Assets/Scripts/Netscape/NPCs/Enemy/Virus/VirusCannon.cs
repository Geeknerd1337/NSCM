using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCannon : AIWeapon
{


    [Header("Visual Effects")]
    public float wobbleHeight;
    public float wobbleSpeed;
    private float index;
    private Vector3 initialPosition;
    [SerializeField]
    private float cannonExtraTurn;

    public Transform cannonParent;
    public Transform player;
    public float rotationSpeed;

    [Header("Flare")]
    private LensFlare flare;
    public Vector2 flareBrightness;
    private float flareIndex;
    private float flareIndexLerp;
    public float flareSpeed;

    public GameObject projectile;
    public Transform firePosition;

    public float cannonRecoil;
    public float cannonRecoilSpeed;
    private float extraFlare;
    public float fireTime;
    private float fireTimer;

    public AudioSource sound;


    private void Start()
    {
        
        index += Random.Range(0, 25);
        transform.parent = cannonParent;
        initialPosition = transform.localPosition;

        player = FindObjectOfType<CyberSpaceFirstPerson>().transform;
        flare = GetComponentInChildren<LensFlare>();
        flareIndex = 0;
        flareIndexLerp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponBob();
        player = controller.CurrentTarget;
        flareIndexLerp = Mathf.Lerp(flareIndexLerp, flareIndex, flareSpeed * Time.deltaTime);
        flare.brightness = Mathf.Lerp(flareBrightness.x, flareBrightness.y, flareIndexLerp) + extraFlare;
        extraFlare = Mathf.Lerp(0, 0.3f, fireTimer / fireTime);
        //Returns cannon extra turn back to zero
        if (Mathf.Abs(cannonExtraTurn) > 0)
        {
            cannonExtraTurn = Mathf.Lerp(cannonExtraTurn, 0, cannonRecoilSpeed * Time.deltaTime);
        }

    }

    private void LateUpdate()
    {
        
    }
    void WeaponBob()
    {
        index += wobbleSpeed * Time.deltaTime;
        transform.localPosition = initialPosition + new Vector3(0, wobbleHeight * Mathf.Sin(index), 0);
        RotateToPlayer();

    }
    public override void FireWeapon(int shots, float time)
    {
        base.FireWeapon(shots, time);
        StartCoroutine(Fire(shots, time));

    }

    IEnumerator Fire(int shots, float time)
    {

        
        while(fireTimer < fireTime)
        {
            fireTimer += Time.deltaTime;
            yield return null;
        }
        fireTimer = 0;
        for (int i = 0; i < shots; i++)
        {
            GameObject g = Instantiate(projectile);
            g.transform.rotation = firePosition.rotation;
            g.transform.position = firePosition.position;
            g.GetComponent<EntityProjectile>().creator = transform;
            
            extraFlare = 0f;
            sound.PlayOneShot(sound.clip);
            yield return new WaitForSeconds(time);
        }
        cannonExtraTurn += cannonRecoil;

        yield return null;

    }

    void CreateProjectile()
    {

    }

    void RotateToPlayer()
    {
        if(player == null)
        {
            return;
        }


        // distance between target and the actual rotating object
        Vector3 D = player.position - transform.position;
        Debug.DrawRay(transform.position, D * 20f);
        Quaternion extra = Quaternion.AngleAxis(cannonExtraTurn,transform.up);
        Quaternion q = Quaternion.LookRotation(D) * extra;
        

        // calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);

        float dot = Quaternion.Dot(rot, Quaternion.LookRotation(D));
        
        if(dot > 0.98f)
        {
            if(Vector3.Distance(transform.position,player.position) < 20f)
            {
                flareIndex = 0.55f;
            }
            else { flareIndex = 0; }
        }

        //Apply the rotation 
        transform.rotation = rot;

        // put 0 on the axys you do not want for the rotation object to rotate
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + cannonExtraTurn, transform.localEulerAngles.z);

    }

    public void OnDeath()
    {
        flare.enabled = false;
    }
}
