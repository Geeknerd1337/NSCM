using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManualSpawnGroupTrigger : MonoBehaviour
{
    public EnemySpawnerGroup spawnGroup;
    private GameObject player;
    private bool hasBeenTriggered = false;
    void Start()
    {
        player = FindObjectOfType<CyberSpaceFirstPerson>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered && other.gameObject == player)
        {
            hasBeenTriggered = true;
            spawnGroup.ForceStartEntranceEffect();
        }    
    }

    void Update()
    {
        
    }
}
