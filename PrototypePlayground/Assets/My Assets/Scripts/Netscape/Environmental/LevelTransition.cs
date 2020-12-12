using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public BoxCollider box;
    public int buildIndex = 1;
    
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<CyberSpaceFirstPerson>().gameObject;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
        }

    }

}
