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

            var data = gameData.BuildingData;

            for (int i = 0; i < buildings.Length; i++)
            {
                if (i >= data.Count) break;
                buildings[i].Initialize(data[i]);
            }
        }

        public List<BuildingData> GetBuildingData()
        {
            var List = new List<BuildingData>();
            for (int i = 0; i < buildings.Length; i++)
            {
                List.Add(new BuildingData(buildings[i].IsUnlock, buildings[i].CurrentLevel));
            }
            return List;
        }
    }
}
