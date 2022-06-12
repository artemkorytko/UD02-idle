using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "UpConf", menuName = "Config/UpConf")]
public class UpgradeConfig : ScriptableObject
{
    [SerializeField] private AssetReference model;
    //увеличениие денег каждую секунду или с открытием нового здания-уровня
    [SerializeField] private int processResult;

    public AssetReference Madel => model;
    public int ProcessResult => processResult;
}
