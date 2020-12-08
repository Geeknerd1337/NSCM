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
    public static string Filename = "gamesave.json";

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
        string saveRelativePath = "Save";
        if (!Directory.Exists(saveRelativePath))
        {
            Directory.CreateDirectory(saveRelativePath);
        }
        var stringData = JsonUtility.ToJson(data);
        string path = saveRelativePath + "/" + filename;
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
    }

    private static SaveLoadData _data;
}