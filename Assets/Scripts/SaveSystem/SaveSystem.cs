using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    public void SaveData(GameData gameData)
    {
        //путь хранения данных
        FileStream dataStream = new FileStream(Application.persistentDataPath + "/gameData.data", FileMode.OpenOrCreate);
        //создать форматор бинарного файла. сериализация форматированных бинарных файлов
        BinaryFormatter converter = new BinaryFormatter();
        //сериализация данных через BinaryFormatter, указываем путь и данные
        converter.Serialize(dataStream, gameData); 
        dataStream.Close();
    }
    public GameData LoadData()
    {
        //существует ли файл по этому пути
        if (File.Exists(Application.persistentDataPath + Application.persistentDataPath + "/gameData.data" ))
        {
        FileStream dataStream = new FileStream(Application.persistentDataPath + "/gameData.data", FileMode.Open);
        BinaryFormatter converter = new BinaryFormatter();
        GameData data = converter.Deserialize(dataStream) as GameData; //превисти данные в фаайле к типу GameDatа
        dataStream.Close();
        return data;
        }
        return new GameData();
    }
}

[Serializable]
public class GameData
{
    private const int BUILDING_COUNT = 4;
    public float Money = 60;

    public List<BuildingData> _BuildingData;
    
    public GameData()
    {
        _BuildingData = new List<BuildingData>();
        for (int i = 0; i < BUILDING_COUNT; i++)
        {
            _BuildingData.Add(new BuildingData());
        }
    }
    [Serializable]
    public class BuildingData
    {
        public readonly bool IsUnLook;
        public readonly int UpgradeLavel;

        public BuildingData()
        {
            IsUnLook = false;
            UpgradeLavel = 0;
        }

        public BuildingData(bool isUnLook, int lavel)
        {
            IsUnLook = isUnLook;
            UpgradeLavel = lavel;
        }
    }
}
