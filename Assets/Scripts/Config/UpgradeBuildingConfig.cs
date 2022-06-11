using Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Config
{
    [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Config/UpgradeConfig")]
    public class UpgradeBuildingConfig : ScriptableObject
    {
        [SerializeField] private float unlockPrice = 30;
        [SerializeField] private float startUpgraideCost = 10;
        [SerializeField] private float costMulriplayer = 1.7f;
        [SerializeField] private UpgradeConfig[] upgrades;

        public float UnlockPrice => unlockPrice;
        public float StartUpgraideCost => startUpgraideCost;
        public float CostMulriplayer => costMulriplayer;
        public UpgradeConfig GetUpgrade(int index)
        {
            if (index < 0 || index >= upgrades.Length)
                return null;
            return upgrades[index];
        }

        public bool IsUpgraide(int index)
        {
            return index >= 0 && index < upgrades.Length;
        }
    }
}
[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Config/UpgradeConfig")]
public class UpgradeBuildingConfig : ScriptableObject
{
    [SerializeField] private float unlockPrice = 30;
    [SerializeField] private float startUpgraideCost=10;
    [SerializeField] private float costMulriplayer=1.7f;
    [SerializeField] private UpgradeConfig[] upgrades;

    public float UnlockPrice => unlockPrice;
    public float StartUpgraideCost => startUpgraideCost;
    public float CostMulriplayer => costMulriplayer;
    public UpgradeConfig GetUpgrade(int index)
    {
        if(index < 0 || index >= upgrades.Length)
            return null;
        return upgrades[index];
    }

    public bool IsUpgraide(int index)
    {
        return index >=0 && index < upgrades.Length;
    }
}
