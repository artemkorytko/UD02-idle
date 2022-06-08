using System;
using DefaultNamespace.Configs;
using Managers;
using UnityEngine;

namespace Levels
{
    public class UpgradableBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradableBuildingConfig config;
        [SerializeField] private Transform buildingRoot;

        private int _currentLevel;
        private GameObject _currentModel;
        
        public bool IsUnlock { get; private set; }

        public int CurrentLevel => _currentLevel;

        public event Action<int> ProcessCompleted; 

        public void Initialize(BuildingData data)
        {
            
        }
    }
}