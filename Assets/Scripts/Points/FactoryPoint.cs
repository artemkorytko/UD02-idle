using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Points
{
    public class FactoryPoint : Point
    {
        [SerializeField] private Text moneyCounter;
        public Text MoneyCounter
        {
            get => moneyCounter;
            set => moneyCounter = value;
        }
        [SerializeField] private Queue<GameObject> buildingStates;
        [SerializeField] private GameObject buildingPoint;
        
        private GameObject _currentBuilding;
        private int earnedMoney;
        private float earnTime;
        private int _stockPrice = 20;
        


        public void Initialize()
        {
            moneyCounter.text = $"Buy {_stockPrice}";
            _currentBuilding = buildingStates.Dequeue();
            Instantiate(_currentBuilding, buildingPoint.transform);
        }

        public void EarnMoney()
        {
            throw new NotImplementedException();
            StartCoroutine();
        }

        public void Upgrade()
        {
            if (buildingStates.Dequeue() != null) 
            {
                _currentBuilding = buildingStates.Dequeue();
            }
            else
            {
                throw new Exception("Больше нет этапов развития");
            }
        }


    }
}