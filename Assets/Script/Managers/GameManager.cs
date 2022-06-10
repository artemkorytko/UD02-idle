using Levels;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private SaveSystem _saveSystem;
        private LevelController _levelController;
        private UIManager _uiManager;


        private void Awake()
        {
            _saveSystem = FindObjectOfType<SaveSystem>();
            _levelController = FindObjectOfType<LevelController>();
            _uiManager = FindObjectOfType<UIManager>();
        }

        public void StartGame()
        {
            _uiManager.SwitchScreen(true);
            _levelController.Initialize(_saveSystem.LoadData());
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void SaveData()
        {
            _saveSystem.SaveData(new GameData() { BuildingData = _levelController.GetBuildingData() });
        }
    }
}
