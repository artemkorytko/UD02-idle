using System;
using System.Collections;
using UnityEngine;


public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private UpgradableBuildingConfig config;
    [SerializeField] private Transform buildingRoot;

    private int _currentLevel;
    private GameObject _currentModel;

    public bool isUnlock { get; private set; }
    public int CurrentLevel => _currentLevel;

    public event Action<int> ProcessComplited;

    public void Initialize(BuildingData data)
    {

    }
}
