using Assets.Scripts.Configs;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts
{
    public class UpgradableBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradableBuildingConfig _config;
        [SerializeField] private Transform buildingRoot;
        [SerializeField] private ButtonController _button;
        private Money money;
        private bool _active;

        private int _currentLevel;
        private GameObject _currentModel;

        public bool IsUnlock { get; private set; }
        public int CurrentLevel => _currentLevel;
        public GameObject CurrentModel => _currentModel;

        public event Action<int> ProcessComplete;

        public void Initialize(BuildingData data)
        {

        }

        private void Start()
        {
            money = FindObjectOfType<Money>();
            IsUnlock = false;
            _active = true;
            UpdateButtonState();
        }

        private void Update()
        {
            if (_active)
            {
                MoneyIncrease();
                _active = false;
            }
        }

        async public void MoneyIncrease()
        {
            await UniTask.Delay(1000);
            money.IsMoney += 1f;
            _active = true;
        }

        public void Upgrade()
        {
            if (!IsUnlock)
            {
                IsUnlock = true;
                UpdateButtonState();
                money.IsMoney -= _config.StartUpgradeCost;
                return;
            }
            if (_config.IsUpgradeExist(_currentLevel + 1))
            {
                _currentLevel++;
                money.IsMoney -= GetCost(_currentLevel);
                UpdateButtonState();
            }
        }

        private void UpdateButtonState()
        {
            if (!IsUnlock)
            {
                _button.UpdateButton("BUY", _config.UnlockPrice);
            }
            if(_config.IsUpgradeExist(_currentLevel + 1))
            {
                _button.UpdateButton("UPGRADE", GetCost(CurrentLevel + 1));
            }
            //else
            //{
            //    _button.gameObject.SetActive(false);
            //}
        }

        private float GetCost(int level)
        {
            return (float)Math.Round(_config.StartUpgradeCost * Math.Pow(_config.CostMultiplier, level));
        }
    }
}