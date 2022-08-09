using System;
using UnityEngine;
using UnityEngine.UI;



namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
        private Level _level;
        [SerializeField] private Button startButton;
        [SerializeField] private Button newGameButton;
        public UIManager uiManager;
        [SerializeField] private SaveSystem _saveSystem;
        private GameData _gameData;
        

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            _level = GetComponentInChildren<Level>();
            _level.gameObject.SetActive(false);
            startButton.onClick.AddListener( () => LoadGame());
            newGameButton.onClick.AddListener(() => NewGame());
            uiManager.Initialize();
        }
        
        
        //Button's methods
        public void LoadGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            _gameData = _saveSystem.LoadData();
            print(_gameData.money);
            _level.Initialize(_gameData);
        }


        public void NewGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            _gameData = new GameData();
            _level.Initialize(_gameData);
        }

        
        // private void OnApplicationQuit()
        // {
        //     SaveData();
        // }

        private void OnApplicationFocus(bool hasFocus)
        {
            SaveData();
        }

        public void SaveData()
        {
            _gameData = _level.GetGameData();
            _saveSystem.SaveData(_gameData);
        }
    }
}
