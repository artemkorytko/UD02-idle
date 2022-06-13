using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SaveSystem _saveSystem = null;
    [SerializeField] private UIController _uiController = null;
    [SerializeField] private FieldManager _fieldManager = null;

    public static GameManager Instance = null;
    public System.Action<float> OnMoneyValueChange = null;

    private float _money = 0;

    public float Money
    {
        get
        {
            return _money;
        }

        set
        {
            if (value >= 0)
            {
                _money = value;
                _money = (float)System.Math.Round(_money, 2);
                OnMoneyValueChange?.Invoke(_money);
            }  
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _saveSystem.Initialize();
        Money = _saveSystem.Data.Money;
        _uiController.ShowMainScreen();
    }

    public void StartGame()
    {
        _uiController.ShowGameScreen();
        _fieldManager.Initialize(_saveSystem.Data);
    }

    private void OnApplicationQuit()
    {
        SaveState();
    }

    private void SaveState()
    {
        _saveSystem.Data.Money = Money;
        _saveSystem.Data.BuildingsData = _fieldManager.GetBuildingData();
        _saveSystem.SaveData();
    }
}
