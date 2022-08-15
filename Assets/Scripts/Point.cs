using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using MyNamespace.Configs;
using Zenject;


namespace MyNamespace
{
    public class Point : MonoBehaviour
    {
        // TODO Прокидывание соединений
        private Level _level;
        
        
        [SerializeField] private PointSettings pointSettings;
        private int _stockMoneyIncome;
        private int _buyPrice;
        private float incomMultiplier;
        private int _incomTime;  
        private float _upgradePriceMultiplier;
        private List<GameObject> buildingStatesModels;


        //всё, что видно игроку
        private Text _collectButtonText;
        [SerializeField] private Button buyButton;
        private Text _buyButtonTxt;
        [SerializeField] private Button collectButton;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private GameObject buildingPoint;
        
        
        private int _upgradeLevel;
        private GameObject _currentBuilding;
        private bool _isUnlocked = false;
        private int _upgradePrice;
        private int _moneyIncome;
        private int _money;  
        private int Money
        { 
            get {return _money;}
            set
            {
                _money = value;
                _collectButtonText.text = $"Collect - {_money.ToString()}";
            }
        }
        public event Action<int> OnMoneyChanged;
        


        private void Awake()
        { 
            _stockMoneyIncome = pointSettings.StockMoneyIncome;
            _buyPrice = pointSettings.BuyPrice;
            incomMultiplier = pointSettings.IncomMultiplier;
            _incomTime = pointSettings.IncomeTime;  
            _upgradePriceMultiplier = pointSettings.UpgradePriceMultiplier;
            buildingStatesModels = pointSettings.BuildingModels;
            
            _level = GetComponentInParent<Level>();
            _buyButtonTxt = buyButton.GetComponentInChildren<Text>();
            _upgradePrice = (int)Math.Round(_buyPrice * _upgradePriceMultiplier);
            _moneyIncome = _stockMoneyIncome;
            _collectButtonText = collectButton.GetComponentInChildren<Text>();
        }
        
        
        public void Initialize(PointData pointData)
        {
            if (pointData.IsUnlocked)
            {
                _isUnlocked = true;
                buyButton.gameObject.SetActive(false);
                collectButton.gameObject.SetActive(true);
                upgradeButton.gameObject.SetActive(true);
                Money = pointData.Money;
                EarnMoney();
                _currentBuilding = Instantiate(buildingStatesModels[0], buildingPoint.transform).gameObject;
                _currentBuilding.transform.localPosition = Vector3.zero;
                for (int i = 0; i < pointData.UpgradeLevel; i++)
                {
                    InitUpgrade();
                }
            }
            else
            {
                upgradeButton.gameObject.SetActive(false);
                collectButton.gameObject.SetActive(false);
                _upgradeLevel = 0;
                _buyButtonTxt.text = $"Buy - {_buyPrice}";
                _currentBuilding = Instantiate(buildingStatesModels[0], buildingPoint.transform).gameObject;
                _currentBuilding.transform.localPosition = Vector3.zero;
            }
        }
        

        public void Buy()
        {
            _isUnlocked = true;
            _upgradePrice = _buyPrice;
            if (_buyPrice <= _level.Money)
            {
                OnMoneyChanged?.Invoke(-_buyPrice);
                buyButton.interactable = false;
                buyButton.gameObject.SetActive(false);
                collectButton.gameObject.SetActive(true);
                upgradeButton.gameObject.SetActive(true);
                EarnMoney();
            }
            else print("Недостаточно денег");
        }


        public PointData GetPointData()
        {
            PointData pointData = new PointData(_isUnlocked, Money, _upgradeLevel);
            return pointData;
        }


        private void InitUpgrade()
        {
            _upgradeLevel++;
            _upgradePrice = (int)Math.Round(_upgradePrice * _upgradePriceMultiplier);
            Destroy(_currentBuilding.gameObject);
            _currentBuilding = Instantiate(buildingStatesModels[_upgradeLevel], buildingPoint.transform);
            _currentBuilding.transform.localPosition = Vector3.zero;
            _moneyIncome = (int)Math.Round(_moneyIncome * incomMultiplier);
        }


        public void Upgrade()
        {
            if (_upgradeLevel < buildingStatesModels.Count -1  && _level.Money >= _upgradePrice)
            {
                OnMoneyChanged?.Invoke(-_upgradePrice);
                _upgradeLevel++;
                _upgradePrice = (int)Math.Round(_upgradePrice * _upgradePriceMultiplier);
                Destroy(_currentBuilding.gameObject);
                _currentBuilding = Instantiate(buildingStatesModels[_upgradeLevel], buildingPoint.transform);
                _currentBuilding.transform.localPosition = Vector3.zero;
                _moneyIncome = (int)Math.Round(_moneyIncome * incomMultiplier);
            }
            else if(_upgradeLevel == buildingStatesModels.Count -1)
            {
                Text buttonText = upgradeButton.GetComponentInChildren<Text>();
                buttonText.text = "max";
                upgradeButton.interactable = false;
            }
        }
        
        
        private async void EarnMoney()     
        {
            while (true)
            {
                await UniTask.Delay(_incomTime); 
                Money += _moneyIncome;
                if (collectButton.gameObject.activeSelf == false)
                {
                    collectButton.gameObject.SetActive(true);
                }
            }
        }


        public void CollectMoney()  // из-за инкапсуляции мы используем именно ивент
        {
            if (_money != 0)
            { 
                OnMoneyChanged?.Invoke(_money);
                Money = 0;
            }
        }
    }
}