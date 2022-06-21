using Managers;
using UnityEngine;
using System.Collections.Generic;

namespace Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private UpgradebleBuilding[] buildings;

        public void Initialize(GameData gameData)
        {
            if (gameData.BuildingData == null) return;

            List<BuildingData> buildingsData = gameData.BuildingData;

            for (int i = 0; i < buildings.Length; i++)
            {
                if (i >= buildingsData.Count) break;
                buildings[i].Initialize(buildingsData[i].IsUnlock, buildingsData[i].UpgradeLevel);
                buildings[i].OnProcessFinished += (int money) => { GameManager.Instance.Money += money; };
            }
        }

        public List<BuildingData> GetBuildingData()
        {
            List<BuildingData> buildingsData = new List<BuildingData>();
            for (int i = 0; i < buildings.Length; i++)
            {
                buildingsData.Add(new BuildingData(buildings[i].IsUnlock, buildings[i].CurrentLevel));
            }
            return buildingsData;
        }
    }
}
