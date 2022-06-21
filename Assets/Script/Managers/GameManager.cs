using Levels;
using UnityEngine;
using System;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private SaveSystem _saveSystem;
        private LevelController _levelController;
        private UIManager _uiManager;

        public static GameManager Instance;
        public Action<float> OnMoneyValueChange;

        private float _money = 0;

        public float Money
        {
            get
            {
                return _money;
            }

            set
            {
                if (value >= 0)
                {
                    _money = value;
                    _money = (float)Math.Round(_money, 2);
                    OnMoneyValueChange?.Invoke(_money);
                }
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            _saveSystem = FindObjectOfType<SaveSystem>();
            _levelController = FindObjectOfType<LevelController>();
            _uiManager = FindObjectOfType<UIManager>();
        }
        public GameData gameData;
        public void StartGame()
        {

            gameData =  _saveSystem.LoadData();
            _money = gameData.Money;
            _uiManager.SwitchScreen(true);
            _levelController.Initialize(gameData);
            //_money = _saveSystem.LoadData().Money;
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void SaveData()
        {
            //_saveSystem.SaveData(new GameData() { Money = _money});
            _saveSystem.SaveData(new GameData() { BuildingData = _levelController.GetBuildingData(), Money = _money });
        }
    }
}
