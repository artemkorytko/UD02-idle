using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Managers
{
  
    public class SaveSystem : MonoBehaviour
    {
        public void SaveData(GameData gameData) 
        {
            FileStream dataStream = new FileStream(Application.persistentDataPath + "/gameData.data", FileMode.OpenOrCreate);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, gameData);
            dataStream.Close();
        }

        public GameData LoadData()
        {
            if (File.Exists(Application.persistentDataPath + "/gameData.data"))
            {
                FileStream dataStream = new FileStream(Application.persistentDataPath + "/gameData.data", FileMode.Open);
                BinaryFormatter converter = new BinaryFormatter();
                GameData data = converter.Deserialize(dataStream) as GameData;
                dataStream.Close();
                return data;
            }

            return new GameData();
        }
    }

    [Serializable]
    public class GameData
    {
        private const int BUILD_COUNT = 4;
        public float Money = 60;
        public List<BuildingData> BuildingData;

        public GameData()
        {
            BuildingData = new List<BuildingData>();
            for (int i = 0; i < BUILD_COUNT; i++)
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

        public BuildingData(bool isUnlock, int level)
        {
            IsUnlock = isUnlock;
            UpgradeLevel = level;
        }

    }
}