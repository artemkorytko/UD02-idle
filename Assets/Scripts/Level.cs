using System.Collections.Generic;
using UnityEngine;


namespace MyNamespace
{
    public class Level : MonoBehaviour
    {
        private GameManager _gameManager;
        [SerializeField] private List<Point> points;
        //[SerializeField] private UIManager uiManager;
        private const int StockMoneyBalance = 60;
        private int _money;
        public int Money  //TODO
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
            }
        }


        private void Awake()
        {
            _gameManager = GetComponentInParent<GameManager>();
        }
        public void Initialize()
        {
            _gameManager.uiManager.EditMoneyCounter(StockMoneyBalance);
            _money = StockMoneyBalance;
            foreach (var point in points)
            {
                point.Initialize();
                point.OnMoneyChanged += ChangeMoney;
            }
        }


        private void ChangeMoney(int money)
        {
            _money += money;
            _gameManager.uiManager.EditMoneyCounter(_money);
        }
    }
}

//TODO Connect Level to UIManager