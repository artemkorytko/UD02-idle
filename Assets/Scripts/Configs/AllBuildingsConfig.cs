using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "AllBuildingsConfig", menuName = "Config/AllBuildingsConfig")]
public class AllBuildingsConfig: ScriptableObject
{
    //стоимость дома на старте игры
    [SerializeField] private float unlockPrice = 30;
    //удорожание постройки, стартовое значение
    [SerializeField] private float startUpgradeCost;
    //умнажаем это значение на стартовое значение unlockPrice с каждым последующим уровнем. Значение будет умнажаться на (наппример) 2 с каждым уровнем
    [SerializeField] private float costMultiplier = 1.7f;
    //массив зданий
    [SerializeField] private UpgradeConfig[] upgrades;

    public float UnlockPrice => unlockPrice;
    public float StartUpgradeCost => startUpgradeCost;
    public float CostMultiplayer => costMultiplier;


    //контроль выдачи зданий
    public UpgradeConfig GetUpgrade(int intdex) 
        {
                if (intdex < 0 || intdex >= upgrades.Length)
                {
                    return null;
                }
                return upgrades[intdex];
        }

    //Доступен ли апгрейд
        public bool IsUpgradeExist(int intdex)
        {
            return intdex >= 0 && intdex < upgrades.Length;
        }

        //дописать логику создания зданий. Подгрузка зданий из ассетов, инстантиэйт на точку на платформе соответсвующей , кажждую секунду начислять столько денег, сколько нужно соотв. злданию
    }


