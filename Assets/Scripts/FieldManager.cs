using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField] private List<UpgradableBuilding> _upgradableBuildings = null;

    public void Initialize(GameData gameData)
    {
        if (gameData.BuildingsData == null) return;

        List<BuildingData> buildingsData = gameData.BuildingsData;

        for (int i = 0; i < _upgradableBuildings.Count; i++)
        {
            if (i >= buildingsData.Count) break;

            _upgradableBuildings[i].Initialize(buildingsData[i].IsUnlock, buildingsData[i].UpgradeLevel);
            _upgradableBuildings[i].OnProcessFinished += (int money) => { GameManager.Instance.Money += money; };
        }
    }

    public List<BuildingData> GetBuildingData()
    {
        List<BuildingData> buildingsData = new List<BuildingData>();

        for (int i = 0; i < _upgradableBuildings.Count; i++)
        {
            buildingsData.Add(new BuildingData(_upgradableBuildings[i].IsUnlock, _upgradableBuildings[i].Level));
        }

        return buildingsData;
    }
}
