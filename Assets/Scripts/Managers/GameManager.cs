using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SaveSystem _saveSystem;
    private LevelController _levelControler;
    private UIManager _uiManager;

    private void Awake()
    {
        _saveSystem = FindObjectOfType<SaveSystem>();
        _levelControler = FindObjectOfType<LevelController>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    public void StartGame()
    {
        _uiManager.SwitchScreens(true);
        _levelControler.Initialize(_saveSystem.LoadData());
    }

   private void OnApplicationQuit()
    {
        SaveData();
    }
    
    private void SaveData()
    {
        _saveSystem.SaveData(new GameData() {_BuildingData = _levelControler.GetBuildingData()});
    }
}
