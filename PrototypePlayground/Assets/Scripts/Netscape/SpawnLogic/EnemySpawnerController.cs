using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawnerController : MonoBehaviour
{
    public float spawnTime = 10.0f;
    public float spawnTimeJitter = 5.0f;
    public float minSpawnTime = 5.0f;
    public bool debugEnabled = false;

    // how long after an enemy dies before we clean it up
    public float timeToCleanupDeadBodies = 10.0f;

    // will not spawn new enemies if there are more than this number of enemies alive
    [SerializeField] private int maxAliveEnemies = 50;


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
        foreach(var group in _spawnerGroups)
        {
            if (group != null)
            {
                group.Init(_spawners);
            }
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
        
        _currentSpawnTime = 
            Mathf.Clamp(spawnTime + Random.Range(-spawnTimeJitter, spawnTimeJitter), minSpawnTime, spawnTime + spawnTimeJitter);
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
            if (group != null && group.CanSpawnEnemies)
            {
                // if the group is running an entrance effect then we skip spawning for this iteration
                if (!group.IsRunningEntranceEffect)
                {
                    PerformSpawn(group);
                }
            }
            ResetTimer();
        }
    }

    private void PerformMaintenenceSweep()
    {
        var enemies = FindObjectsOfType<AIEntity>();
        int numEnemies = enemies.Count();
        foreach (var enemy in enemies)
        {
            var health = enemy.gameObject.GetComponent<EntityHealth>();
            if (health.IsDead)
            {
                Destroy(enemy.transform.root.gameObject, timeToCleanupDeadBodies);
                numEnemies--;
            }
        }
        _lastCachedEnemyCount = numEnemies;
    }

    private void PerformSpawn(EnemySpawnerGroup group)
    {
        PerformMaintenenceSweep();
        if (_lastCachedEnemyCount < maxAliveEnemies)
        {
            var spawner = group.GetRandomSpawner();
            if (spawner != null)
            {
                spawner.Spawn();
            }
        }
    }

    private void OnGUI()
    {
        if (debugEnabled)
        {
            GUI.Label(new Rect(25, 25, 1000, 50),"current spawn timer = " + _currentSpawnTime);
            GUI.Label(new Rect(25, 45, 1000, 50),"last cached num alive enemies" + _lastCachedEnemyCount);
            GUI.Label(new Rect(25, 65, 1000, 50),"max allowed alive enemies " + maxAliveEnemies);
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

    private int _lastCachedEnemyCount = 0;

}
