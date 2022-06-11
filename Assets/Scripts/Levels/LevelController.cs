using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private UpgradeBuildingConfig[] buildings;

        public void Initialize(GameData gameData)
        {
            if (gameData.BuildingData == null) return;

            var data =gameData.BuildingData;

            foreach(var building in buildings)
            {
                building.In
            }
        }

        public List<BuildingData> GetBuildingData()
        {

        }
    }
}

