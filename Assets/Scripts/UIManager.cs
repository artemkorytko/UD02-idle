using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private Text moneyCounterText;
        private GameObject _currentScreen;

        public Text MoneyCounterText
        {
            get => moneyCounterText;
            set => moneyCounterText = value;
        }


        private void Awake() 
        {
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