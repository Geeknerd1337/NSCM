using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveDataController : MonoBehaviour
{
    void Start()
    {
        SaveLoadGlobalManager.Save();
    }

    void Update()
    {
        
    }

    public void LoadAutosave()
    {
        throw new NotImplementedException();
    }

    public void OnDeath()
    {

            //yield return new WaitForSeconds(3);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

        // todo load in health and ammo values


    }
}
