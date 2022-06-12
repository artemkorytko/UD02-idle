using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableBuilding : MonoBehaviour
{
    [SerializeField] private UpgradableBuildingConfig config;
    [SerializeField] private Transform buildingRoot;

    private int _currentLevel;
    private GameObject _currentModel;

    public bool IsUnlock { get; private set; }

    public int CurrentLevel => _currentLevel;

    public event System.Action<int> ProcessCompleted;

    public void Initialize(BuildingData data)
    {

    }
}
