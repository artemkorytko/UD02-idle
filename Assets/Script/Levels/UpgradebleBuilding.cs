using Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;
using System;

namespace Levels
{
    public class UpgradebleBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradebleBuildingConfig config;
        [SerializeField] private Transform buildingRoot;
        [SerializeField] private UpgradeButton button;

        private GameObject _currentModel;
        private Coroutine _timer;

        public Action<int> OnProcessFinished;

        public bool IsUnlock { get; private set; } = false;

        public int CurrentLevel  => _currentLevel;

        private int _currentLevel = -1;

        public void Initialize(bool isUnlock, int upgradeLevel = -1)
        {
            IsUnlock = isUnlock;
            _currentLevel = upgradeLevel;

            if (IsUnlock && _currentLevel >= 0) SetModel(_currentLevel);
            UpdateButtonState();
            GameManager.Instance.OnMoneyValueChange += button.OnMoneyValueChanged;
        }

        public void Upgrade()
        {
            if (!IsUnlock)
            {
                IsUnlock = true;
                UpdateButtonState();
                GameManager.Instance.Money -= config.UnlockPrice;
                return;
            }

            if (config.IsUpgradeExist(_currentLevel + 1))
            {
                _currentLevel++;
                GameManager.Instance.Money -= GetCost(_currentLevel);
                StartCoroutine(SetModel(_currentLevel));
                UpdateButtonState();
            }
        }
        private IEnumerator SetModel(int level)
        {
            UpgradeConfig upgradeConfig = config.GetUpgrade(level);

            if (_currentModel != null)
            {
                Addressables.ReleaseInstance(_currentModel);
            }

            AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync(upgradeConfig.Model, buildingRoot);

            yield return handler;
            _currentModel = handler.Result;
            _currentModel.transform.localPosition = Vector3.zero;

            if (_timer == null)
            {
                _timer = StartCoroutine(Timer());
            }
        }
        private void UpdateButtonState()
        {
            if (!IsUnlock)
            {
                button.UpdateButton("BUY", config.UnlockPrice);
                return;
            }

            if (config.IsUpgradeExist(_currentLevel + 1))
            {
                button.UpdateButton("UPGRADE", GetCost(_currentLevel + 1));
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                OnProcessFinished?.Invoke(config.GetUpgrade(_currentLevel).ProcessResult);
            }
        }

        private float GetCost(int level)
        {
            return (float)Math.Round(config.StartUpgradeCost * Mathf.Pow(config.CostMultiplier, level), 2);
        }
    }
}
