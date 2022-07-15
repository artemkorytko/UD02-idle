using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuScreen;
        [SerializeField] private GameObject gameScreen;
        [SerializeField] private Text moneyCounter;
        private GameObject _currentScreen;


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


        public void EditMoneyCounter( int money)
        {
            moneyCounter.text = money.ToString();
        }
    }
}