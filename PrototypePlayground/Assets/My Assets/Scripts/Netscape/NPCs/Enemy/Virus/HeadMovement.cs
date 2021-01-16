using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    public float rotateSpeed;
    public float offset;
    public Vector3 myDir;
    public EntityLimb limb;
    public float offsetSpeed;

    public GameObject head;
    public GameObject explodeHead;
    public ParticleSystem ps;
    public AudioSource sound;
    public ParticleSystem ps2;
    // Start is called before the first frame update
    void Start()
    {
        limb = GetComponent<EntityLimb>();
        explodeHead.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        offset = Mathf.Lerp(offset, 0, offsetSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        RotateHead();
    }
    void RotateHead()
    {

        // distance between target and the actual rotating object

        Quaternion extra = Quaternion.AngleAxis(offset, transform.right);
        extra = Quaternion.Euler(Vector3.Cross(Vector3.up,limb.incomingDamageDir) * offset);
        Quaternion q = Quaternion.Euler(Vector3.up) * extra;


        // calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);


        //Apply the rotation 
        transform.rotation = rot;

        // put 0 on the axys you do not want for the rotation object to rotate
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

    }

    public void ShutOff()
    {
        this.enabled = false;
    }

    public void HitMe()
    {
        offset = 90f;
    }

    public void Die()
    {
        explodeHead.SetActive(true);
        head.SetActive(false);
        ps.Play();
        ps2.Play();
        sound.Play();
        ShutOff();
    }
}
