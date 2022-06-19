using Assets.Scripts.Configs;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts
{
    public class UpgradableBuilding : MonoBehaviour
    {
        [SerializeField] private UpgradableBuildingConfig config = null;
        [SerializeField] private Transform modelsContainer = null;
        [SerializeField] private ButtonController button = null;

        private int _currentLevel;
        private GameObject currentModel = null;
        private Coroutine timer = null;
        public Action<int> OnProcessFinished = null;

        public bool IsUnlock { get; private set; } = false;
        public int CurrentLevel => _currentLevel;

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

            if (currentModel != null)
            {
                Addressables.ReleaseInstance(currentModel);
            }
            
            AsyncOperationHandle<GameObject> handler = Addressables.InstantiateAsync(upgradeConfig.Model, modelsContainer);
            yield return handler;
            currentModel = handler.Result;
            currentModel.transform.localPosition = Vector3.zero;
            
            if (timer == null)
            {
                timer = StartCoroutine(MoneyIncrease());
            }
        }

        private IEnumerator MoneyIncrease()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                OnProcessFinished?.Invoke(config.GetUpgrade(_currentLevel).ProcessResult);
            }
        }
        
        private void UpdateButtonState()
        {
            if (!IsUnlock)
            {
                button.UpdateButton("BUY", config.UnlockPrice);
            }
            else if(config.IsUpgradeExist(_currentLevel + 1))
            {
                button.UpdateButton("UPGRADE", GetCost(CurrentLevel + 1));
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }

        private float GetCost(int level)
        {
            return (float)Math.Round(config.StartUpgradeCost * Math.Pow(config.CostMultiplier, level), 2);
        }
    }
}