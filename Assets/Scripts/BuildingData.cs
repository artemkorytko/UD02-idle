using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingData
{
    public bool IsUnlock = false;
    public int UpgradeLevel = -1;

    public BuildingData()
    {
        IsUnlock = false;
        UpgradeLevel = -1;
    }

    public BuildingData(bool isUnlock, int level)
    {
        IsUnlock = isUnlock;
        UpgradeLevel = level;
    }
}
