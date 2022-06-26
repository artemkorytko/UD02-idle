using System;
using UnityEngine;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelController _levelController;
    private UIManager _uiManager;
    private FirebaseManager _firebaseManager;
    private GameData _gameData;
    private int _buildingsCount;

    public int BuildingsCount
    {
        get
        {
            return _buildingsCount;
        }
        set
        {
            if (value > 0 && value < 5)
            {
                _buildingsCount = value;
            }
            else
            {
                _buildingsCount = 4;
            }
        }
    }

    public event Action<float> OnMoneyUpdate;

    private async void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _levelController = FindObjectOfType<LevelController>();
        _uiManager = FindObjectOfType<UIManager>();
        _firebaseManager = FindObjectOfType<FirebaseManager>();

        await _firebaseManager.Initialize(this);
        await _firebaseManager.RemoteConfigBuildingsCount();
        
        BuildingsLevelCheck(null);
    }

    public async void StartGame()
    {
        var firebaseGameData = await _saveSystem.LoadDataFirebase();
        _gameData = _saveSystem.LoadDataLocally();
        
        if (firebaseGameData != null)
        {
            _gameData.Money = firebaseGameData.Money;
        }

        _uiManager.Initialize(this);
        _levelController.Initialize(_gameData, this, _buildingsCount);
        
        _uiManager.SwitchScreens(true);
        OnMoneyUpdate?.Invoke(_gameData.Money);
        
        Debug.Log("Game started");
        throw new Exception("Crashlytics test exception");
    }

    private void SaveData()
    {
        if (_gameData == null) return;
        
        _saveSystem.SaveDataLocally(new GameData() { BuildingDataList = _levelController.GetBuildingData()});
        _saveSystem.SaveDataFirebase(new GameData() { Money = _gameData.Money });
    }

    public void IncreaseMoney(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        _gameData.Money += value;

        OnMoneyUpdate?.Invoke(_gameData.Money);
    }

    public void DecreaseMoney(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        _gameData.Money -= value;

        OnMoneyUpdate?.Invoke(_gameData.Money);
    }

    public void BuildingsLevelCheck([CanBeNull] string buildingName)
    {
        var buildingsList = _levelController.GetBuildingData();
        var buildingsMaxLevel = _levelController.GetBuildingsMaxLevel();
        var maxLevelBuildingsCount = 0;

        if (buildingName != null)
        {
            _firebaseManager.BuildingMaxLevelEvent(buildingName);
        }

        foreach (var building in buildingsList)
        {
            if (building.UpgradeLevel == buildingsMaxLevel)
            {
                maxLevelBuildingsCount++;
            }
        }

        if (maxLevelBuildingsCount == _buildingsCount)
        {
            _firebaseManager.AllBuildingsMaxLevelEvent();
        }
    }

    public void BuildingUnlocked(string buildingName)
    {
        _firebaseManager.BuildingUnlockEvent(buildingName);
    }
    
    public void BuildingUpgrated(string buildingName, int level)
    {
        _firebaseManager.LevelUpEvent(buildingName, level);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveData();           
        }
    }
}
