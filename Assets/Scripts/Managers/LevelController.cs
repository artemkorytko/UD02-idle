using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    [SerializeField] private UpgradableBuilding[] buildings;

    public void Initialize(GameData gameData)
    {
        if (gameData.BuildingData == null) return;

        var data = gameData.BuildingData;

        for (int i = 0; i < buildings.Length; i++)
        {
            if (i > data.Count) break;

            buildings[i].Initialize(data[i]);
        }
    }

    public List<BuildingData> GetBuildingData()
    {
        var list = new List<BuildingData>();

        for (int i = 0; i < buildings.Length; i++)
        {
            list.Add(new BuildingData(buildings[i].isUnlock, buildings[i].CurrentLevel));
        }

        return list;
    }
}