using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections.Generic;

namespace Manager
{
    public class SaveSystem : MonoBehaviour
    {
        private static readonly string Path = Application.persistentDataPath + "/gameData.data";
        public void SaveData(GameData gameData)
        {
            FileStream dataStream = new FileStream(Path, FileMode.OpenOrCreate);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, gameData);
            dataStream.Close();
        }
        public GameData LoadDara()  
        {
            if (File.Exists(Path))
            {
                FileStream dataStream = new FileStream(Path, FileMode.Open);
                BinaryFormatter converter = new BinaryFormatter();
                GameData data = converter.Deserialize(dataStream) as GameData;
                dataStream.Close();
                return data; 
            }
            else return new GameData();
        }

    }
    [Serializable]
    public class GameData
    {
        private const int BUILD_COUN = 4;
        public float Money = 60;

        public List<BuildingData> BuildingData;

        public GameData() 
        {
            BuildingData =new List<BuildingData>();
            for (int i = 0; i < BUILD_COUN; i++)
            {
                BuildingData.Add(new BuildingData());
            }
        }
     }       
    [Serializable]
    public class BuildingData
    {
        public readonly bool IsUnlock =false;
        public readonly int UpgradeLevel = 0;

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
}


