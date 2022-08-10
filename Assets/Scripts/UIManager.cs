using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private Text moneyCounterText;
        private GameObject _currentScreen;

        public Text MoneyCounterText => moneyCounterText;


        private void Awake() 
        {
            if (instance == null) 
            { 
                instance = this; // Задаем ссылку на экземпляр объекта
                if (instance== null)
                {
                    Debug.Log("UIManager nulllllllllll");
                }
            } 
            else if(instance == this)// Экземпляр объекта уже существует на сцене
            { 
                Destroy(gameObject); // Удаляем объект
            }
            DontDestroyOnLoad(gameObject);
            
            Initialize();
        }

        
        public void Initialize()
        {
            gameScreen.SetActive(false);
            _currentScreen = mainMenuScreen;
            _currentScreen.SetActive(true);
        }


        public void ShowGameScreen()
        {
            _currentScreen.SetActive(false);
            _currentScreen = gameScreen;
            _currentScreen.SetActive(true);
        }
        
        
        public void ShowMainMenuScreen()
        {
            _currentScreen.SetActive(false);
            _currentScreen = mainMenuScreen;
            _currentScreen.SetActive(true);
        }
    }
}