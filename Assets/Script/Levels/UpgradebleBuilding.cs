using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class UpgradebleBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradebleBuildingConfig config;
        [SerializeField] private Transform buildingRoot;

        private int _currentLevel;
        private GameObject _currentModel;
        public bool IsUnlock { get; private set; }
        public int CurrentLevel  => _currentLevel;

        public void Initialize(BuildingData data)
        {
            
        }
       
    }
}
