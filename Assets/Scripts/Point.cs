using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;



namespace MyNamespace
{
    public class Point : MonoBehaviour
    {
        //всё, что видно игроку
        private Text _moneyCounterTxt; 
        [SerializeField] private Button buyButton;
        private Text _buyButtonTxt;
        [SerializeField] private Button collectButton;
        [SerializeField] private Button upgradeButton;
        [SerializeField] private List<GameObject> buildingStatesModels;
        [SerializeField] private GameObject buildingPoint;
        private GameObject _currentBuilding;
        

        private const float StockMoneyIncome = 1f;
        private float _moneyIncome;
        private const float IncomMultiplier = 1.2f;
        private int _incomTime = 5000;  //mSeconds
        private int _money;  //TODO сделать свойство
        
        public event Action<int> OnMoneyCollected;

        
        public int Money 
        { 
            get {return _money;}
            set { _money = value;}
        }
        
        private const float PointPrice = 20f;
        

        public void Initialize()
        {
            _moneyIncome = StockMoneyIncome;
            _moneyCounterTxt = collectButton.gameObject.GetComponentInChildren<Counter>().text;
            _buyButtonTxt = buyButton.GetComponentInChildren<Text>();
            _buyButtonTxt.text = $"Buy - {StockPrice}";
            upgradeButton.gameObject.SetActive(false);
            collectButton.gameObject.SetActive(false);
            _currentBuilding = buildingStatesModels[0];
            buildingStatesModels.Remove(_currentBuilding);
            Instantiate(_currentBuilding, buildingPoint.transform);
            _currentBuilding.transform.position = Vector3.zero;
        }
        

        public void Buy()
        {
            if (PointPrice  )
            {
                
            }
            buyButton.interactable = false;
            buyButton.gameObject.SetActive(false);
            collectButton.gameObject.SetActive(true);
            upgradeButton.gameObject.SetActive(true);
            EarnMoney();
        }
        
        
        public void Upgrade()
        {
            _currentBuilding = buildingStatesModels[0];
            buildingStatesModels.Remove(_currentBuilding);
            _moneyIncome *= IncomMultiplier;
            //throw new Exception("Больше нет этапов развития");
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


        public void CollectMoney()
        {
            if (_money != 0)
            {
                int money = _money;
                _money = 0;
                OnMoneyCollected?.Invoke(money);
            }
        }
    }
}


//TODO Срочно поменять взаимодействие уровня с точкой с помощью делегатов и событий, так же подписать на событие точки наш UIManager;
//TODO Почитать за Action, за ивенты ты уже читал
//TODO Либо SingleTOn, либо костыли

//TODO Connect Level to UIManager   !!!