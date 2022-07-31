using UnityEngine;
using UnityEngine.UI;



namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
        private Level _level;
        [SerializeField] private Button startButton;
        public UIManager uiManager;
        [SerializeField] private SaveSystem _saveSystem;
        private GameData _gameData;
        

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();
            _level = GetComponentInChildren<Level>();
            _level.gameObject.SetActive(false);
            startButton.onClick.AddListener( () => StartGame());   //TODO разобраться бы с кнопками
            uiManager.Initialize();
        }
        
        
        //Button's methods
        public void StartGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            if (_saveSystem == null) print("нет сейв системы");
            _gameData = _saveSystem.LoadData();
            _level.Initialize(_gameData);
        }

        
        private void OnApplicationQuit()
        {
            SaveData();
            Application.Quit();
        }

        public void SaveData()
        {
            _gameData = _level.GetGameData();
            _saveSystem.SaveData(_gameData);
        }
    }
}
