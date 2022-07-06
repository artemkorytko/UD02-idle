using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

namespace MyNameSpace
{
    public class Point : MonoBehaviour
    {
        [SerializeField] public Text moneyCounterTxt; 
        [SerializeField] public Text BuyButtonTxt;
        [SerializeField] private Queue<GameObject> buildingStatesModels;
        [SerializeField] private GameObject buildingPoint;
        private GameObject _currentBuilding;
        
        private float _stockMoneyIncome = 1f;
        private float _moneyIncom;
        private float _IncomMultiplier = 1.2f;
        private float _earnedMoney;
        private int _incomTime = 1000;  //mSeconds
        
        private float _stockPrice = 20f;
        

        public void Initialize()
        {
            moneyCounterTxt.text = "0";
            BuyButtonTxt.text = $"Buy {_stockPrice}";
            _moneyIncom = _stockMoneyIncome;
            _currentBuilding = buildingStatesModels.Dequeue();
            Instantiate(_currentBuilding, buildingPoint.transform);
        }

        
        public void EarnMoney()
        {
            //StartCoroutine();
            _earnedMoney += _moneyIncom;
        }

        
        public void Upgrade()
        {
            if (buildingStatesModels.Dequeue() != null)
            {
                _currentBuilding = buildingStatesModels.Dequeue();
                if ( (_moneyIncom * _IncomMultiplier)%10 != 0)
                {
                    _moneyIncom = (_moneyIncom * _IncomMultiplier)/10;
                }
                else _moneyIncom = (_moneyIncom * _IncomMultiplier);
            }
            else
            {
                throw new Exception("Больше нет этапов развития");
            }
        }
    }
}