using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuilding : MonoBehaviour
{
    //config for all buildings
    [SerializeField] private AllBuildingsConfig allBuildingsConfig;
    //точка инстантиэйта здания
    [SerializeField] private Transform buildingRoot;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _button;

    //текущий уровень
    private int _currentLevel;
    //текущая модель здания, которую можно удалить и записать-создать новую
    private GameObject _currentModel;

    //подписка на событие, когда происходит тик здания
    public event Action<int> ProcessCompleted;

    //заблокировано ли здание
    public bool IsUnLook {get; private set;}

    //прочитать текущий уровень
    public int CurrentLevel => _currentLevel;

    public void Initialize(GameData.BuildingData data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        IsUnLook = true;
        
    }
}
