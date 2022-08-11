using UnityEngine;
using UnityEngine.UI;



namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public static GameManager Instance;
        private Level _level;
        [SerializeField] private Button startButton;
        [SerializeField] private Button newGameButton;
        private UIManager uiManager;
        [SerializeField] private SaveSystem saveSystem;
        
        private GameData _gameData;
        
        

        private void Awake() 
        {
            if (instance == null) 
            { 
                instance = this; // Задаем ссылку на экземпляр объекта
            } 
            else if(instance == this)// Экземпляр объекта уже существует на сцене
            { 
                Destroy(gameObject); // Удаляем объект
            }
            DontDestroyOnLoad(gameObject);
        }


        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            uiManager = UIManager.instance;
            _level = GetComponentInChildren<Level>();
            if (_level == null)
            {
                Debug.Log("Level null");
            }
            _level.gameObject.SetActive(false);
            startButton.onClick.AddListener( () => LoadGame());
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
