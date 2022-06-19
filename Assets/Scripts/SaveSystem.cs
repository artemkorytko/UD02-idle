using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    private static string Path;
    private void Awake()
    {
         Path = Application.persistentDataPath + "/gameDataTest1.data";
    }

    public void SaveData(GameData gameData)
    {
        FileStream dataStream = new FileStream(Path, FileMode.OpenOrCreate);
        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, gameData);
        dataStream.Close();
    }

    public GameData LoadData()
    {
        if (File.Exists(Path)) 
        {
            FileStream dataStream = new FileStream(Path, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            GameData data = converter.Deserialize(dataStream) as GameData;
            dataStream.Close();
            return data;
        }
        else
        {
            return new GameData();
        }
    }
}

[Serializable]
public class GameData
{
    private const int BUILD_COUNT = 4;
    public float Money = 0;
    public List<BuildingData> BuildingData;

    public GameData()
    {
        BuildingData = new List<BuildingData>();
        for(int i = 0; i < BUILD_COUNT; i++)
        {
            BuildingData.Add(new BuildingData());
        }
    }
}

[Serializable]
public class BuildingData
{
    public readonly bool IsUnlock;
    public readonly int UpgradeLevel;

    public BuildingData()
    {
        IsUnlock = false;
        UpgradeLevel = 0;
    }

    public BuildingData(bool isUnlock, int upgradeLevel)
    {
        IsUnlock = isUnlock;
        UpgradeLevel = upgradeLevel;
    }
}
