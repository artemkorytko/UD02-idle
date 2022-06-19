using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private SaveSystem _saveSystem;
        private LevelController _LevelController;
        private UIManager _UIManager;
        public static GameManager Instance = null;

        private float _money = 60;
        public System.Action<float> OnMoneyValueChange = null;

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
                    _money = (float) System.Math.Round(_money, 2);
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
            _LevelController = FindObjectOfType<LevelController>();
            _UIManager = FindObjectOfType<UIManager>();
            StartGame();
        }

        private void StartGame()
        {
            _UIManager.SwitchScreen(true);
            _LevelController.Initialize(_saveSystem.LoadData());
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                SaveData();
            }
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void SaveData()
        {
            _saveSystem.SaveData(new GameData() { BuildingData = _LevelController.GetBuildingData() });
        }
    }
}
