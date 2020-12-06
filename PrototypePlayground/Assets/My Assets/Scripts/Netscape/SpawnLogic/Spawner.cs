using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
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
}
