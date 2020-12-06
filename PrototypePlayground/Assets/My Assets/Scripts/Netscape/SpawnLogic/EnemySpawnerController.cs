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
            _player = playerTest.gameObject;
        }
        foreach(var group in spawnGroups)
        {
            group.Init(_spawners);
        }

        // temp
        Activate();
    }

    public void Activate()
    {
        _active = true;
    }


    private void ResetTimer()
    {
        _currentSpawnTime = spawnTime;

    }

    void Update()
    {
        if (!_active || _player == null)
        {
            return;
        }

        //if (!_debugHasSpawnedOnce)
        //{
        //    _debugHasSpawnedOnce = true;
        //    foreach(var group in spawnGroups)
        //    {
        //        group.GetRandomSpawner().Spawn();
        //    }    
        //}

        _currentSpawnTime -= Time.deltaTime;
        if (_currentSpawnTime <= 0)
        {
            var group = FindBestSpawnGroup();
            if (group != null)
            {
                group.GetRandomSpawner().Spawn();
            }
            ResetTimer();
        }
    }

    private EnemySpawnerGroup FindBestSpawnGroup()
    {
        EnemySpawnerGroup FindClosestSpawnGroup(List<EnemySpawnerGroup> spawnGroups)
        {
            float distance = float.MaxValue;
            EnemySpawnerGroup spawnGroup = null;
            foreach (var currentSpawnGroup in spawnGroups)
            {
                float curDistance = (currentSpawnGroup.gameObject.transform.position - _player.transform.position).magnitude;
                if (curDistance < distance)
                {
                    spawnGroup = currentSpawnGroup;
                    distance = curDistance;
                }
            }
            if (spawnGroup == null)
            {
                Debug.LogError("Somehow couldn't find an appropriate spawn group");
            }
            return spawnGroup;
        }
        // first see if the player is inside any spawn group
        List<EnemySpawnerGroup> spawnQuery = new List<EnemySpawnerGroup>();
        foreach (var spawnGroup in _spawnerGroups)
        {
            if (spawnGroup.groupVolume.bounds.Contains(_player.transform.position))
            {
                spawnQuery.Add(spawnGroup);
            }
        }
        //  if player is in exactly one spawn group then we've found our group
        if (spawnQuery.Count == 1)
        {
            return spawnQuery[0];
        }
        // else if the player intersects more than one or zero spawn groups we pick the closest one to the player
        else
        {
            EnemySpawnerGroup spawnGroup = FindClosestSpawnGroup(_spawnerGroups);
            return spawnGroup;
        }
    }

    //private bool _debugHasSpawnedOnce = false;

    private bool _active = false;


    private float _currentSpawnTime = 0.0f;

    private GameObject _player;

    private List<EnemySpawnerGroup> _spawnerGroups = new List<EnemySpawnerGroup>();
    private List<EnemySpawner> _spawners = new List<EnemySpawner>();

}
