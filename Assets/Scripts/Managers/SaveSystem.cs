using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using Cysharp.Threading.Tasks;

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

    public async void SaveDataFirebase(GameData data)
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        await reference.Child("GameData").SetRawJsonValueAsync(JsonUtility.ToJson(data));
    }

    public async UniTask<GameData> LoadDataFirebase()
    {
        GameData data = null;
        var getValueTask = FirebaseDatabase.DefaultInstance.GetReference("GameData").GetValueAsync();
        
        await getValueTask.ContinueWithOnMainThread(async task => {
          await UniTask.WaitWhile(() => task.IsCompleted == false);
          if (task.IsFaulted)
          {
            // Handle the error...
          }
          else if (task.IsCompleted)
          {
            DataSnapshot snapshot = task.Result;
            data = JsonUtility.FromJson<GameData>(snapshot.GetRawJsonValue());
          }
        }); 
        await UniTask.WaitWhile(() => data == null);
        return data;
    }
}

[Serializable]
public class GameData
{
    private const int BUILD_COUNT = 4;
    public float Money = 50;
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
