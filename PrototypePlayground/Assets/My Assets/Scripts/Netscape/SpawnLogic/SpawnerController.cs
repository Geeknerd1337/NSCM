using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<SpawnerGroup> spawnGroups;

    void Start()
    {
        var playerTest = FindObjectOfType<CyberSpaceFirstPerson>();
        if (playerTest == null)
        {
            Debug.LogError("Unable to get player ref");
        }
        else
        {
            playerRef = playerTest.gameObject;
        }
    }

    void Update()
    {
        
    }

    private GameObject playerRef;
}
