using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace.Configs
{
    [CreateAssetMenu(fileName = "PointConfig", menuName = "Configs/PointConfig", order = 0)]
    public class PointConfig : ScriptableObject
    {
        [SerializeField] private int stockMoneyIncome;
        [SerializeField] private int buyPrice;
        [SerializeField] private float incomMultiplier;
        [SerializeField] private int incomeTime;//mSeconds
        [SerializeField] private float upgradePriceMultiplier;
        [SerializeField] private List<GameObject> buildingModels;


        public int StockMoneyIncome => stockMoneyIncome;

        public int BuyPrice => buyPrice;

        public float IncomMultiplier => incomMultiplier;

        public int IncomeTime => incomeTime;

        public float UpgradePriceMultiplier => upgradePriceMultiplier;

        public List<GameObject> BuildingModels => buildingModels;
    }
}