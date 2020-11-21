using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShardManager : MonoBehaviour
{

    public List<WeaponShard> ws;
    public float amt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeMe()
    {
        foreach(WeaponShard w in ws)
        {
            w.shakeMod = amt;
        }
    }
}
