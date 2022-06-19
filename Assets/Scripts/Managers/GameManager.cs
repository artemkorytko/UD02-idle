using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelController _levelController;
    private UIManager _uiManager;

    private void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();   
        _levelController = FindObjectOfType<LevelController>(); 
        _uiManager = FindObjectOfType<UIManager>();
    }

    public void StartGame()
    {
        _uiManager.SwitchScreens(true);
        _levelController.Initialize(_saveSystem.LoadData());

    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveData();
        }
    }

    private void OnAplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        _saveSystem.SaveData(new GameData() { BuildingData = _levelController.GetBuildingData() });
    }
}
