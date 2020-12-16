using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelSaveDataController : MonoBehaviour
{

    private PlayerStats playerStats;
    private WeaponManager weaponManager;
    private GunSelectionUI gunUI;
    private float fov;
    public float FOV
    {
        get
        {
            return fov;
        }

        set
        {
            fov = value;
        }
    }

    [SerializeField]
    private AudioMixer mixer;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetSettings();
        }

        playerStats = FindObjectOfType<PlayerStats>();
        weaponManager = FindObjectOfType<WeaponManager>();
        if (weaponManager != null)
        {
            weaponManager.GunUI.gameObject.SetActive(true);
            gunUI = weaponManager.GunUI;
            weaponManager.GunUI.gameObject.SetActive(false);
        }

        Debug.Log(gunUI + " " + weaponManager);

        SaveLoadGlobalManager.Load();
        if (SaveLoadGlobalManager.HasValidData)
        {
            // Do all data loading here
            if (playerStats != null)
            {


                var data = SaveLoadGlobalManager.Data;
                playerStats.Health = data.health;
                playerStats.Shield = data.sheild;

                for (int i = 0; i < weaponManager.guns.Count; ++i)
                {
                    if (data.weaponUnlocks[i] == true)
                    {
                        weaponManager.UnlockWeapon(i);
                    }
                    var weapon = weaponManager.GetWeaponFromIndex(i);
                    if (weapon != null)
                    {
                        weapon.ShotsLeft = data.weaponAmmoCounts[i];
                    }
                }
            }
        }
        if (weaponManager != null)
        {
            Save();
        }


    }

  

    public void Save()
    {
        var data = SaveLoadGlobalManager.Data;

        data.health = playerStats.Health;
        data.sheild = playerStats.Shield;
        data.level = SceneManager.GetActiveScene().buildIndex;

        // weaponmanager : bool array for weapon ownership
        var guns = new List<bool>(weaponManager.guns.Count);
        for (int i = 0; i < weaponManager.guns.Count; ++i)
        {
            
            if (gunUI.weaponSlots[i] == null) // null means doesn't own weapon?
            {
                guns.Add(false);
            }
            else
            {
                guns.Add( gunUI.weaponSlots[i].HasWeapon);
            }
        }
        data.weaponUnlocks = guns;

        // weapon.shotsleft
        var ammos = new List<int>(weaponManager.guns.Count);
        for (int i = 0; i < weaponManager.guns.Count; ++i)
        {
            var weapon = weaponManager.GetWeaponFromIndex(i);
            if (weapon != null)
            {
                ammos.Add( weapon.ShotsLeft);
            }
            else
            {
                ammos.Add(0);
            }
        }
        data.weaponAmmoCounts = ammos;
        SaveLoadGlobalManager.Save();
    }


    // If we're just starting the level we want to first load all our ammo and health values but we
    // don't want to load the level endlessly so we use this.
    public void LoadAutosave()
    {
        SaveLoadGlobalManager.Load();
    }

    // Launches the level in the autosave. This is what you would use when you die 
    public void LaunchAutosaveLevel()
    {
        SaveLoadGlobalManager.Load();
        var data = SaveLoadGlobalManager.Data;
        Debug.Log(data.health);
        SceneManager.LoadScene(data.level, LoadSceneMode.Single);

    }

    public void OnDeath()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void SaveSettings(SettingsSaveLoadData externalData)
    {
        var data = SaveLoadSettingManager.Data;
        data.fov = externalData.fov;
        Debug.Log(data.fov + "boppo" + externalData.fov);
        data.resolutionSelection = externalData.resolutionSelection;
        data.resolutionSelectionIndex = externalData.resolutionSelectionIndex;
        data.musicVolume = externalData.musicVolume;
        data.sfxVolume = externalData.sfxVolume;
        data.graphicsSelection = externalData.graphicsSelection;
        data.fullscreen = externalData.fullscreen;
        SaveLoadSettingManager.Save();
    }

    public void SetSettings()
    {
        SaveLoadSettingManager.Load();
        if (SaveLoadSettingManager.HasValidData)
        {
            var data = SaveLoadSettingManager.Data;
            Screen.SetResolution(data.resolutionSelection.width, data.resolutionSelection.height, Screen.fullScreen);
            
            mixer.SetFloat("SFXvolume", data.sfxVolume);

            mixer.SetFloat("MusicVolume", data.musicVolume);
            Screen.fullScreen = data.fullscreen;
            QualitySettings.SetQualityLevel(data.graphicsSelection);
            SaveLoadSettingManager.FOV = data.fov;

        }
    }
}
