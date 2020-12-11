using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveLoadData
{
    public int level  ;
    public int health  ;

    // etc etc
}

// use this static interface from anywhere to set the current data as well saving it and loading it from file
public static class SaveLoadGlobalManager
{
    public static SaveLoadData Data => _data;
    public const string Filename = "gamesave.json";
    public const string SavePath = "Save";

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
    }

    public static void Load()
    {
        Load(Filename);
    }

    public static void Load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        string jsonData = reader.ReadToEnd();
        reader.Close();
        SaveLoadData data = JsonUtility.FromJson<SaveLoadData>(jsonData);
        _data = data;
        // call function that actually does something with new save data (change level, adjust ammo etc)
    }

    private static SaveLoadData _data;
}