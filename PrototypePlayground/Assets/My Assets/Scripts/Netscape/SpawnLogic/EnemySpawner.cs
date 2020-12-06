using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabToSpawn;
    public int level = 1;

    public void Spawn()
    {
        Instantiate(enemyPrefabToSpawn, gameObject.transform.position, gameObject.transform.rotation);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
