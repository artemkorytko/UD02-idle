using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;


namespace MyNamespace
{
    public class Point : MonoBehaviour
    {
        //всё, что видно игроку
        private Level _level;
        private Text _moneyCounterTxt; 
        [SerializeField] private Button buyButton;
        private Text _buyButtonTxt;
        [SerializeField] private Button collectButton;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private List<GameObject> buildingStatesModels;
        [SerializeField] private GameObject buildingPoint;
        private GameObject _currentBuilding;
        
        private const float StockMoneyIncome = 3f;
        private float _moneyIncome;
        private float IncomMultiplier = 1.2f;
        private int _incomTime = 2000;  //mSeconds
        private int _money;  //TODO сделать свойство
        public int Money 
        { 
            get {return _money;}
            set { _money = value;}
        }
        private int PointPrice = 20;
        private int _upgradePrice;
        private float _upgradePriceMultiplier = 6;
        public event Action<int> OnMoneyChanged;


        public void Initialize()
        {
            _level = GetComponentInParent<Level>();
            _moneyIncome = StockMoneyIncome;
            _moneyCounterTxt = collectButton.gameObject.GetComponentInChildren<Counter>().text;
            _buyButtonTxt = buyButton.GetComponentInChildren<Text>();
            _buyButtonTxt.text = $"Buy - {PointPrice}";
            upgradeButton.gameObject.SetActive(false);
            collectButton.gameObject.SetActive(false);
            _currentBuilding = Instantiate(buildingStatesModels[0], buildingPoint.transform).gameObject;
            buildingStatesModels.Remove(buildingStatesModels[0]);
            _currentBuilding.transform.localPosition = Vector3.zero;
            _upgradePrice = PointPrice / 10;
        }
        

        public void Buy()
        { 
            if (PointPrice <= _level.Money)
            {
                OnMoneyChanged?.Invoke(-PointPrice);
                buyButton.interactable = false;
                buyButton.gameObject.SetActive(false);
                collectButton.gameObject.SetActive(true);
                upgradeButton.gameObject.SetActive(true);
                EarnMoney();
            }
            else print("Недостаточно денег");
        }
        
        
        public void Upgrade()
        {
            if (buildingStatesModels.Count != 0 && _level.Money >= _upgradePrice)
            {
                OnMoneyChanged?.Invoke(-_upgradePrice);
                _upgradePrice = (int)Math.Round(_upgradePrice * _upgradePriceMultiplier);
                Destroy(_currentBuilding.gameObject);
                _currentBuilding = Instantiate(buildingStatesModels[0], buildingPoint.transform);
                buildingStatesModels.Remove(buildingStatesModels[0]);
                _currentBuilding.transform.localPosition = Vector3.zero;
                _moneyIncome *= IncomMultiplier;
            }
        }
        
        
        private async void EarnMoney()     
        {
            while (true)
            {
                await UniTask.Delay(_incomTime); 
                _money += (int)Math.Round(_moneyIncome);
                _moneyCounterTxt.text = $"Collect {_money.ToString()}";
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
                _money = 0;
                _moneyCounterTxt.text = $"Collect {_money.ToString()}";
            }
        }
    }
}