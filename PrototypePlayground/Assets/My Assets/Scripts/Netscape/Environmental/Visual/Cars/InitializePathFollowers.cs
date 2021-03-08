using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class InitializePathFollowers : MonoBehaviour
{

    public List<PathFollower> followers;
    // Start is called before the first frame update
    void Start()
    {
        float f = 0;
        foreach(PathFollower p in followers)
        {
            p.distanceTravelled = f;
            f += Random.Range(150f, 300f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
