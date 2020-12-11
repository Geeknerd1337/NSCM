using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveDataController : MonoBehaviour
{

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();


        SaveLoadGlobalManager.Save();

    }

    void Update()
    {
        
    }

    public void LoadAutosave()
    {
        SaveLoadGlobalManager.Load();
        var data = SaveLoadGlobalManager.Data;
        playerStats.Health = data.health;
        playerStats.Shield = data.sheild;


    }

    public void OnDeath()
    {

            //yield return new WaitForSeconds(3);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);



        // todo load in health and ammo values


    }
}
