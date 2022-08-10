using System.Collections.Generic;
using UnityEngine;


namespace MyNamespace
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Point> points;
        private int _money;
        public int Money 
        {
            get
            {
                return _money;
            }
        }
        private UIManager uiManager;

        
        
        public void Initialize(GameData gameData)
        {
            uiManager = UIManager.instance;
            _money = gameData.money;
            uiManager.MoneyCounterText.text = _money.ToString();

            for (int i = 0; i < points.Count; i++)
            {
                points[i].Initialize(gameData.pointData[i]);
                points[i].OnMoneyChanged += ChangeMoney;
            }
        }


        public GameData GetGameData()
        {
            List < PointData > pointsData = GetPointsData();
            GameData gameData = new GameData(points.Count, _money, pointsData);
            return gameData;
        }
        
        
        public List<PointData> GetPointsData()
        {
            List<PointData> pointsData = new List<PointData>();
            for (int i = 0; i < points.Count; i++)
            {
                pointsData.Add(points[i].GetPointData());
            }

            return pointsData;
        }


        private void ChangeMoney(int money)
        {
            _money += money;
            uiManager.MoneyCounterText.text = _money.ToString();
        }
    }
}

