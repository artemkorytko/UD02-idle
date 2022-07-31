using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace MyNamespace
{
    public class Level : MonoBehaviour
    {
        private GameManager _gameManager;
        [SerializeField] private List<Point> points;
        //[SerializeField] private UIManager uiManager;
        private int _money;
        public int Money  //TODO
        {
            get
            {
                return _money;
            }
        }


        private void Awake()
        {
            _gameManager = GetComponentInParent<GameManager>();
        }
        
        
        public void Initialize(GameData gameData)
        {
            _money = gameData.money;
            _gameManager.uiManager.EditMoneyCounter(_money);
            
            for (int i = 0; i < points.Count; i++)
            {
                points[i].Initialize(gameData.PointData[i]);
                points[i].OnMoneyChanged += ChangeMoney;
            }
        }


        public GameData GetGameData()
        {
            GameData gameData = new GameData(points.Count, _money, GetPointsData());
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
            _gameManager.uiManager.EditMoneyCounter(_money);
        }
    }
}

//TODO Connect Level to UIManager