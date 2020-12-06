using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGroup : MonoBehaviour
{
    public BoxCollider groupVolume;

    public int SpawnerCount => _spawners.Count;

    public void Init(List<EnemySpawner> spawners)
    {
        // find all spawners inside our volume and cache them
        foreach (var spawner in spawners)
        {
            if (groupVolume.bounds.Contains(spawner.gameObject.transform.position))
            {
                _spawners.Add(spawner);
            }
        }
        //Debug.Log("number of spawners in group is" + spawners.Count);
    }

    public EnemySpawner GetRandomSpawner()
    {

        return _spawners[Random.Range(0, _spawners.Count - 1)];
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private List<EnemySpawner> _spawners = new List<EnemySpawner>();

}