using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
     
        [Inject] private UIManager uiManager;
        private Level _level;
        [SerializeField] private Button playButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private SaveSystem saveSystem;
        
        private GameData _gameData;
        
        


        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _level = GetComponentInChildren<Level>();
            if (_level == null)
            {
                Debug.Log("Level null");
            }
            _level.gameObject.SetActive(false);
            playButton.onClick.AddListener( () => LoadGame());
            newGameButton.onClick.AddListener(() => NewGame());
        }
        
        
        //Button's methods
        private void LoadGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            _gameData = saveSystem.LoadData();
            _level.Initialize(_gameData);
        }


        private void NewGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            _gameData = new GameData();
            _level.Initialize(_gameData);
        }

    #if UNITY_EDITOR
        private void OnApplicationQuit()
        {
            SaveData();
        }
    #elif UNITY_ANDROID || UNITY_IOS
        private void OnApplicationFocus(bool hasFocus)
        {
            SaveData();
        }
    #endif
        public void SaveData()
        {
   
            _gameData = _level.GetGameData();
            saveSystem.SaveData(_gameData);// нулл
        }
    }
}
