using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShard : MonoBehaviour
{
    public Vector3 speeds;
    private Vector3 times;
    private Vector3 origPosition;
    private Vector3 perlins;
    public float amt;
    public float returnSpeed;
    public float shakeMod;
    public Animator a;
    // Start is called before the first frame update
    void Start()
    {
        origPosition = transform.localPosition;
        times = Vector3.one * Random.Range(0, 25f);
    }

    private void Update()
    {
        shakeMod = Mathf.MoveTowards(shakeMod, 1, returnSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (a == null)
        {
            MoveMe();
        }
        else
        {
            if (a.GetBool("isAiming"))
            {
                MoveMe();
            }
            else
            {
                
            }
        }
    }

    void MoveMe()
    {
        origPosition = transform.localPosition;
        times.x += Time.deltaTime * speeds.x * shakeMod;
        times.y += Time.deltaTime * speeds.y * shakeMod;
        times.z += Time.deltaTime * speeds.z * shakeMod;

        perlins.x = Mathf.PerlinNoise(times.x, times.x);
        perlins.y = Mathf.PerlinNoise(times.y, times.y);
        perlins.z = Mathf.PerlinNoise(times.z, times.z);

        transform.localPosition = origPosition + perlins * amt;
    }
}
