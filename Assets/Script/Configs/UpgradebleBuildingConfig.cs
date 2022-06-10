using UnityEngine;
using UnityEngine.AddressableAssets;


[CreateAssetMenu(fileName = "UpgradebleBuildingConfig", menuName = "Config/UpgradebleBuildingConfig", order = 0)]
public class UpgradebleBuildingConfig : ScriptableObject
{
    [SerializeField] private float unlockPrice = 30;
    [SerializeField] private float startUpgradeCost = 10;
    [SerializeField] private float costMultiplier = 1.7f;
    [SerializeField] private UpgradeConfig[] upgrades;

    public float UnlockPrice => unlockPrice;

    public float StartUpgradeCost => startUpgradeCost;

    public float CostMultiplier => costMultiplier;

    public UpgradeConfig GetUpgrade (int index)
    {
        if (index < 0 || index > upgrades.Length)
        return null;
        return upgrades[index];
    }

    public bool IsUpgradeExist(int index)
    {
        return index >= 0 && index < upgrades.Length;
    }
}
