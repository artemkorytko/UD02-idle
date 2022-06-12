using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelConroller _levelController;
    private UIManager _uiManager;

    private void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _levelController = FindObjectOfType<LevelConroller>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    public void StartGame()
    {
        _uiManager.SwitchScreen(true);
        _levelController.Initialize(_saveSystem.LoadData());
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

    private void SaveData()
    {
        _saveSystem.SaveData(new GameData() { BuildingData = _levelController.GetBuildingData() });
    }
}
