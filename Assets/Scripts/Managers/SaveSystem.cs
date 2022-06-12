using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static readonly string Path = "/gameData.data";

    public void SaveData(GameData gameData)
    {
        FileStream dataStream = new FileStream(Application.persistentDataPath + Path, FileMode.OpenOrCreate);
        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, gameData);
        dataStream.Close();
    }

    public GameData LoadData()
    {
        if (File.Exists(Application.persistentDataPath + Path))
        {
            FileStream dataStream = new FileStream(Application.persistentDataPath + Path, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            var gameData = converter.Deserialize(dataStream) as GameData;
            dataStream.Close();
            return gameData;
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
    public float Money = 60;
    public List<BuildingData> BuildingDataList;

    public GameData()
    {
        BuildingDataList = new List<BuildingData>();
        for (int i = 0; i < BUILD_COUNT; i++)
        {
            BuildingDataList.Add(new BuildingData());
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

    public BuildingData(bool isUnlock, int level)
    {
        IsUnlock = isUnlock;
        UpgradeLevel = level;
    }
}
