using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    
    private SaveSystem _saveSystem;
    private LevelController _levelControler;
    private UIManager _uiManager;

    public event Action<float> OnMoneyUpdate;

    private void Awake()
    {
        _saveSystem = GetComponent<SaveSystem>();
        _levelControler = FindObjectOfType<LevelController>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    
    public void IncreaseMoney(float value)
    {
        
    }

    public void StartGame()
    {
        _uiManager.SwitchScreens(true);
        _levelControler.Initialize(_saveSystem.LoadData());
    }
    private void SaveData()
    {
        _saveSystem.SaveData(new GameData() {_BuildingData = _levelControler.GetBuildingData()});
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
