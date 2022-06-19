using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private UpgradableBuildingConfig config;
    [SerializeField] private Transform buildingPlace;

    private GameObject _currentModel;
    private UpgradeButton _upgradeButton;
    private Coroutine _coroutine;
    private int _currentLevel;
    private int _generatedMoney;
    private float _upgradeCost;
    private bool _isMaxLevel;

    private const string _unlockText = "BUY";
    private const string _upgradeText = "UP lvl.";
    private const string _maxLevelText = "MAX";

    public bool IsUnlock { get; private set; }
    public int CurrentLevel => _currentLevel;
    public float UpgradeCost => _upgradeCost;

    public event Action<float> ProcessCompleted;
    public event Action<float> OnDecreaseMoney;

    public void Initialize(BuildingData data, GameManager gameManager)
    {
        _upgradeButton = GetComponentInChildren<UpgradeButton>();
        _currentLevel = data.UpgradeLevel;
        IsUnlock = data.IsUnlock;

        ProcessCompleted += gameManager.IncreaseMoney;
        OnDecreaseMoney += gameManager.DecreaseMoney;
        gameManager.OnMoneyUpdate += UpdateButtonState;

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
        if (_isMaxLevel) return;

        if (!IsUnlock)
        {
            UnlockLevel();
        }
        else
        {
            var index = _currentLevel + 1;

            if (config.IsUpgradeExist(index))
            {
                _currentLevel++;
                UpdateStates();
            }
        }
    }

    private void UnlockLevel()
    {
        IsUnlock = true;
        UpdateStates();
    }

    private void UpdateStates()
    {
        var levelConfig = config.GetUpgrade(_currentLevel);
        SetBuilding(levelConfig);
        _generatedMoney = levelConfig.ProcessResult;
        OnDecreaseMoney?.Invoke(_upgradeCost);

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseMoney());
        }

        if (_currentLevel == config.MaxUpgrade())
        {
            _upgradeButton.UpdateButtonText(_maxLevelText, " ");
            _isMaxLevel = true;
        }
        else
        {
            UpdateUpgradeCost(_currentLevel);
            _upgradeButton.UpdateButtonText(_upgradeText + " " + (_currentLevel + 1), _upgradeCost.ToString());
        }
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

    private async void SetBuilding(UpgradeConfig config)
    {
        if (_currentModel != null)
        {
            Addressables.ReleaseInstance(_currentModel);
        }

        _currentModel = await Addressables.InstantiateAsync(config.Model, gameObject.transform);
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
            ProcessCompleted?.Invoke(_generatedMoney);
        }
    }
}
