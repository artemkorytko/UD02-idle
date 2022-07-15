using UnityEngine;

namespace MyNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Level level;
        [SerializeField] private UIManager uiManager;

        
        private void Awake()
        {
            uiManager.Initialize();
        }
    
    
        
        
        //Button's methods
        public void StartGame()
        {
            level = Instantiate(level.gameObject, transform).GetComponent<Level>();
            level.Initialize();
            uiManager.ShowGameScreen();
        }

        public void ExitGame()
        {
            //Application.
        }
    }
}
