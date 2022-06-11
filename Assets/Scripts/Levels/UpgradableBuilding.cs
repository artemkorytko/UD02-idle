using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class UpgradableBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradeBuildingConfig config;
        [SerializeField] private Transform buildingRoot;

        private int _currentLevel;
        private GameObject _currentModel;

        public bool IsUnLock { get; private set; }

        public int CurrentLevel => _currentLevel;

        public void Initialaze(BuildingData buildingData)
        {

        }
    }
}

