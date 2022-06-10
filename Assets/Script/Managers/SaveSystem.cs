using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace Managers
{

    public class SaveSystem : MonoBehaviour
    {
        private static readonly string Path = Application.persistentDataPath + "/gameData.data";
        public void SaveData(GameData gamedata)
        {
            FileStream dataStream = new FileStream(Path, FileMode.OpenOrCreate);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, gamedata );
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
        public bool IsUnlock;
        public int UpgradeLevel;

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