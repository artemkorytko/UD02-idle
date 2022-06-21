using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private UpgradableBuilding[] buildings;

    public void Initialize(GameData gameData, GameManager gameManager, int buildingsCount)
    {
        if (gameData.BuildingDataList == null) return;

        var data = gameData.BuildingDataList;

        for (int i = 0; i < buildings.Length; i++)
        {
            if (i >= data.Count) break;

            if (i > (buildingsCount - 1) && buildingsCount > 0)
            {
                buildings[i].gameObject.SetActive(false);
            }
            else
            {
                buildings[i].Initialize(data[i], gameManager);
            }
        }
    }

    public List<BuildingData> GetBuildingData()
    {
        var list = new List<BuildingData>();

        for (int i = 0; i < buildings.Length; i++)
        {
            list.Add(new BuildingData(buildings[i].IsUnlock, buildings[i].CurrentLevel));
        }

        return list;
    }
}
