using UnityEngine;
using UnityEngine.UI;



namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
        private Level _level;
        [SerializeField] private Button startButton;
        public UIManager uiManager;

        private void Awake()
        {
            _level = GetComponentInChildren<Level>();
            _level.gameObject.SetActive(false);
            startButton.onClick.AddListener( () => StartGame());
            uiManager.Initialize();
        }
        
        
        //Button's methods
        public void StartGame()
        {
            uiManager.ShowGameScreen();
            _level.gameObject.SetActive(true);
            _level.Initialize();
        }

        public void ExitGame()
        {
            //Application.
        }
    }
}
