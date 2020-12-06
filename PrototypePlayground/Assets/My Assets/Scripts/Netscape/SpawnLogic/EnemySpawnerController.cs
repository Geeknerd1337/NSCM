using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemySpawnerController : MonoBehaviour
{
    public EnemySpawnerGroup[] spawnGroups;

    public float spawnTime = 10.0f;

    void Start()
    {
        _spawners = FindObjectsOfType<EnemySpawner>().ToList();
        _spawnerGroups = FindObjectsOfType<EnemySpawnerGroup>().ToList();
        var playerTest = FindObjectOfType<CyberSpaceFirstPerson>();
        if (playerTest == null)
        {
            Debug.LogError("Unable to get player ref");
        }
        else
        {
            playerRef = playerTest.gameObject;
        }
        foreach(var group in spawnGroups)
        {
            group.Init(_spawners);
        }
    }

    void Update()
    {
        if (!_debugHasSpawnedOnce)
        {
            _debugHasSpawnedOnce = true;
            foreach(var group in spawnGroups)
            {
                group.GetRandomSpawner().Spawn();
            }    
        }
    }

    private bool _debugHasSpawnedOnce = false;

    private GameObject playerRef;

    private List<EnemySpawnerGroup> _spawnerGroups = new List<EnemySpawnerGroup>();
    private List<EnemySpawner> _spawners = new List<EnemySpawner>();

}
