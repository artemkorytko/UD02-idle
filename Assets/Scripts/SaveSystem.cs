using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    private static readonly string Path = Application.persistentDataPath + "/gameData.data";//readOnly))
    public void SaveData(GameData gameData)
    {
        FileStream dataStream = new FileStream(Path, FileMode.OpenOrCreate);
        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, converter);
        dataStream.Close();
    }
     
    public GameData LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.data"))
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

    public GameData<BuildingData> BuildingData;

    public GameData ()
    {
        BuildingData = new List<BuildingData>();
    }


}



public class BuildingData
{

}
