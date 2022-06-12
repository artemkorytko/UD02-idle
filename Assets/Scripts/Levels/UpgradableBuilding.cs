using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private UpgradableBuildingConfig config;
    [SerializeField] private Transform buildingPlace;

    private GameObject _currentModel;
    private int _currentLevel;
    private int _generateadMoney;
    private float _upgradeCost;
    private UpgradeButton _upgradeButton;
    private Coroutine _coroutine;

    private const string _unlockText = "BUY";
    private const string _upgradeText = "UP lvl.";
    private const string _maxLevelText = "MAX";

    public bool IsUnlock { get; private set; }
    public int CurrentLevel => _currentLevel;
    public float UpgradeCost => _upgradeCost;

    public event Action<float> ProcessCompleted;
    public event Action<float> OnDecreaseMoney;

    public void Initialize(BuildingData data)
    {
        _upgradeButton = GetComponentInChildren<UpgradeButton>();
        _currentLevel = data.UpgradeLevel;
        IsUnlock = data.IsUnlock;

        if (IsUnlock)
        {
            UpdateStates();
        }
        else
        {
            _upgradeCost = config.UnlockPrice;
            _upgradeButton.UpdateButtonText(_unlockText, _upgradeCost.ToString());
        }
    }

    public void UpdateLevel()
    {
        if (!IsUnlock) IsUnlock = true;

        var index = _currentLevel + 1;

        if (config.IsUpgradeExist(index))
        {
            _currentLevel++;
            UpdateStates();
        }
        else
        {
            SetBuilding(config.MaxUpgrade());
            _upgradeButton.UpdateButtonText(_maxLevelText, " ");
        }
    }

    private void UpdateStates()
    {
        var levelConfig = config.GetUpgrade(_currentLevel);
        SetBuilding(_currentLevel);
        _generateadMoney = levelConfig.ProcessResult;
        OnDecreaseMoney?.Invoke(_upgradeCost);

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseMoney());
        }

        UpdateUpgradeCost(_currentLevel);
        _upgradeButton.UpdateButtonText(_upgradeText + " " + _currentLevel, _upgradeCost.ToString());
    }

    public void UpdateButtonState(float money)
    {
        if (_upgradeCost < money && _upgradeButton.IsInteractable == false)
        {
            _upgradeButton.SetInteractable(true);
        }
        else if (_upgradeCost > money && _upgradeButton.IsInteractable == true)
        {
            _upgradeButton.SetInteractable(false);
        }
    }

    private void SetBuilding(int index)
    {
        var levelConfig = config.GetUpgrade(index);

        if (_currentModel != null)
        {
            Destroy(_currentModel);
        }

        var currentObject = Addressables.InstantiateAsync(levelConfig.Model, gameObject.transform);
        _currentModel = currentObject.Result;
    }

    private void UpdateUpgradeCost(int levelIndex)
    {
        _upgradeCost = config.StartUpgradeCost + (config.StartUpgradeCost * config.CostMultiplier * levelIndex);
    }

    private IEnumerator IncreaseMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ProcessCompleted?.Invoke(_generateadMoney);
        }
    }
}
