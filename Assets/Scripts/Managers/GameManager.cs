using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Firebase.Extensions;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelController _levelController;
    private UIManager _uiManager;
    private GameData _gameData;
    private int _buildingsCount;

    public event Action<float> OnMoneyUpdate;

    private async void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _levelController = FindObjectOfType<LevelController>();
        _uiManager = FindObjectOfType<UIManager>();
        
        await BuildingsCountRemoteConfig();
        Console.WriteLine($"BuildingsCount {_buildingsCount}"); // Эта строка никогда не выводится в консоли,
                                                                // хотя Remout Config загружается успешно
    }

    public async void StartGame()
    {
        Console.WriteLine("Start method");
        GameData gameData = await _saveSystem.LoadDataFirebase(); 
        Console.WriteLine("Load Data from Firebase completed");
        
        _gameData = _saveSystem.LoadData();
        if (gameData != null)
        {
            _gameData.Money = gameData.Money;
        }

        _uiManager.Initialize(this);
        _levelController.Initialize(_gameData, this, _buildingsCount);
        
        _uiManager.SwitchScreens(true);
        OnMoneyUpdate?.Invoke(_gameData.Money);
    }

    private async UniTask BuildingsCountRemoteConfig()
    {
        var fetchTask = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        await fetchTask.ContinueWithOnMainThread(CheckValue);
    }

    private async UniTask CheckValue(Task obj)
    {
        await Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("building_amount");
        _buildingsCount = (int)value.LongValue;
    }

    private void SaveData()
    {
        if (_gameData == null) return;
        
        _saveSystem.SaveData(new GameData() { BuildingDataList = _levelController.GetBuildingData()});
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

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
