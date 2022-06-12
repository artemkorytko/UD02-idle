using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelController _levelController;
    private UIManager _uiManager;
    private GameData _gameData;

    public event Action<float> OnMoneyUpdate;

    private void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _levelController = FindObjectOfType<LevelController>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    public void StartGame()
    {
        _uiManager.SwitchScreens(true);
        _gameData = _saveSystem.LoadData();
        _levelController.Initialize(_gameData, IncreaseMoney, DecreaseMoney, ref OnMoneyUpdate);
        OnMoneyUpdate += _uiManager.UpdateGamePanel;
        _uiManager.UpdateGamePanel(_gameData.Money);
    }

    private void SaveData()
    {
        _saveSystem.SaveData(new GameData() { BuildingDataList = _levelController.GetBuildingData(), Money = _gameData.Money});
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

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
