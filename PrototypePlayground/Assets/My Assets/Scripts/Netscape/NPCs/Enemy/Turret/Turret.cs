using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [SerializeField]
    private Transform turretTransform;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float heightOffset = 1f;
    [SerializeField]
    private float bobSpeed;
    [SerializeField]
    private float bobAmt;
    private float bobStart;

    [SerializeField]
    private float fireTime;
    [SerializeField]
    private Transform firePosition;
    [SerializeField]
    private GameObject projecTile;
    private float fireTimer;

    [SerializeField]
    private float range;
    [SerializeField]
    private LayerMask lm;

    private CyberSpaceFirstPerson player;
    private Vector3 origPostion;
    private bool aggro;
    private bool dead;

    [SerializeField]
    private ParticleSystem p;

    private float ztar;

    public float zspeed;
    public float recoil;

    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CyberSpaceFirstPerson>();
        origPostion = turretTransform.localPosition;
        //Baba
    }

    public void Die()
    {
        p.transform.rotation = turretTransform.rotation;
        p.Play();
        dead = true;
        Destroy(turretTransform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }

        if (!aggro)
        {
            if (PlayerFound())
            {
                aggro = true;
            }
        }
        if (aggro)
        {
            RotateToPlayer();
            FireGun();
        }
        BobTurret();
    }

    void BobTurret()
    {
        bobStart += Time.deltaTime * bobSpeed;
        float mod = Mathf.PerlinNoise(0, bobStart) * bobAmt;
        Vector3 vec = new Vector3(origPostion.x, origPostion.y + mod, origPostion.z) - turretTransform.right * ztar;
        turretTransform.localPosition = vec;
        ztar = Mathf.Lerp(ztar, 0, zspeed * Time.deltaTime);
    }

    void RotateToPlayer()
    {
        Vector3 dir = (player.transform.position + (Vector3.up * heightOffset) - turretTransform.position).normalized;
        Quaternion lookDir = Quaternion.LookRotation(dir);
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, lookDir, rotationSpeed * Time.deltaTime);
    }

    void FireGun()
    {
        Vector3 dir = (player.transform.position + (Vector3.up * heightOffset) - turretTransform.position).normalized;
        if (Vector3.Dot(dir, turretTransform.transform.forward) >= 0.85f)
        {
            fireTimer += Time.deltaTime;
        }
        else
        {
            fireTimer = 0;
        }
        if(fireTimer > fireTime)
        {
            
            GameObject g = Instantiate(projecTile);
            g.transform.position = firePosition.transform.position;
            g.transform.rotation = Quaternion.LookRotation(turretTransform.forward);

            ztar = recoil;
            fireTimer = 0;
        }
    }

    bool PlayerFound()
    {
        RaycastHit hit;
        
        if(Physics.SphereCast(turretTransform.position,2f,turretTransform.forward,out hit,range,lm))
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
            
        }
        if(Vector3.Distance(transform.position,player.transform.position) < range * 0.65f)
        {
            return true;
        }
        return false;
    }
}
