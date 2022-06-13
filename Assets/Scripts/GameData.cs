using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float Money = 60;
    public List<BuildingData> BuildingsData;

    public GameData()
    {
        BuildingsData = new List<BuildingData>();

        for (int i = 0; i < 4; i++)
        {
            BuildingsData.Add(new BuildingData());
        }
    }
}
