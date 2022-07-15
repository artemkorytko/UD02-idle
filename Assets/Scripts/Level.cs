using System.Collections.Generic;
using UnityEngine;


namespace MyNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Point> points;
        private UIManager _uIManager;
        
        
        private bool _isInitialized;
        private const int StockMoneyBalance = 20;
        private int _money;
        public int Money { get; set; }
        
        
        public void Initialize()
        {
            _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
            _uIManager.EditMoneyCounter(StockMoneyBalance);
            foreach (var point in points)
            {
                _isInitialized = true;
                point.Initialize();
                point.OnMoneyCollected += GetMoney;
                point.OnMoneyCollected += _uIManager.EditMoneyCounter;
            }
        }


        private void Update()      //TODO May be add an Action
        {
            if (_isInitialized)
            {
                _uIManager.EditMoneyCounter(_money);
            }
        }


        private void GetMoney(int money)
        {
            _money += money;
        }
    }
}

//TODO Connect Level to UIManager