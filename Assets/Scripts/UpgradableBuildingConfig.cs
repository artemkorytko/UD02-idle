using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Config", menuName = "Configs/Building Config")]
public class UpgradableBuildingConfig : ScriptableObject
{
    [SerializeField] private float _unlockPrice = 0;
    [SerializeField] private float _startUpgradeCost = 0;
    [SerializeField] private float _costMultiplier = 0;
    [SerializeField] private List<UpgradeConfig> _upgrades = null;

    public float UnlockPrice => _unlockPrice;
    public float StartUpgeadeCost => _startUpgradeCost;
    public float Multiplier => _costMultiplier;
    public int UpgradeCount => _upgrades.Count;

    public bool IsUpgradeExist(int index)
    {
        return index >= 0 && index < _upgrades.Count;
    }

    public UpgradeConfig GetUpgrade(int index)
    {
        if (index >= _upgrades.Count) return null;

        return _upgrades[index];
    }
}
