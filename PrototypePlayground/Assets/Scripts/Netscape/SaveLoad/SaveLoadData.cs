﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveLoadData
{
    // level uses buildindex
    public int level;

    public float health;
    public float sheild;

    public List<bool> weaponUnlocks = new List<bool>();

    public List<int> weaponAmmoCounts = new List<int>();

    // etc etc
}

[Serializable]
public class SettingsSaveLoadData
{
    public float fov;
    public float musicVolume;
    public float sfxVolume;
    public int resolutionSelectionIndex;
    public bool fullscreen;
    public int graphicsSelection;
    public int resWidth;
    public int resHeight;
}

// use this static interface from anywhere to set the current data as well saving it and loading it from file
public static class SaveLoadGlobalManager
{
    public static SaveLoadData Data => _data;
    public const string Filename = "autosave.json";
    public const string SavePath = "Save";
    public static bool HasValidData { get; private set; } = false;


    static SaveLoadGlobalManager()
    {
        _data = new SaveLoadData();
    }
        
    public static void Save()
    {
        Save(_data, Filename);
    }

    public static void Save(SaveLoadData data, string filename)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        var stringData = JsonUtility.ToJson(data);
        string path = SavePath + "/" + filename;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(stringData);
        writer.Close();
        HasValidData = true;
    }

    public static void Load()
    {
        Load(SavePath + "/" + Filename);
    }

    public static void Load(string filename)
    {
        if (File.Exists(filename))
        {
            StreamReader reader = new StreamReader(filename);
            string jsonData = reader.ReadToEnd();
            reader.Close();
            SaveLoadData data = JsonUtility.FromJson<SaveLoadData>(jsonData);
            _data = data;
            HasValidData = true;
        }
        // since this is not a monobehavior we can't look up components. All this load does is makes sure 
        // the autosave is loaded. The data is used to initalize various things inside LevelSaveDataController
    }

    public static void Delete()
    {
        string filename = SavePath + "/" + Filename;
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
    }

    private static SaveLoadData _data;
}

public static class SaveLoadSettingManager
{
    public static SettingsSaveLoadData Data => _settingData;
    public const string Filename = "settings.json";
    public const string SavePath = "Settings";
    public static bool HasValidData { get; private set; } = false;

    //User settings that need to updated in scene, using this singleton to manage them
    public static float FOV;

    static SaveLoadSettingManager()
    {
        _settingData = new SettingsSaveLoadData();
    }

    public static void Save()
    {
        Save(_settingData, Filename);
    }

    public static void Save(SettingsSaveLoadData data, string filename)
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
        var stringData = JsonUtility.ToJson(data);
        string path = SavePath + "/" + filename;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(stringData);
        writer.Close();
        HasValidData = true;
    }

    public static void Load()
    {
        Load(SavePath + "/" + Filename);
    }

    public static void Load(string filename)
    {
        if (File.Exists(filename))
        {
            StreamReader reader = new StreamReader(filename);
            string jsonData = reader.ReadToEnd();
            reader.Close();
            SettingsSaveLoadData data = JsonUtility.FromJson<SettingsSaveLoadData>(jsonData);
            _settingData = data;
            HasValidData = true;
        }
        // since this is not a monobehavior we can't look up components. All this load does is makes sure 
        // the autosave is loaded. The data is used to initalize various things inside LevelSaveDataController
    }

    private static SettingsSaveLoadData _settingData;
}