using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private SaveSystem _saveSystem;
        private LevelController _LevelController;
        private UIManager _UIManager;

        private void Awake()
        {
            _saveSystem = FindObjectOfType<SaveSystem>();
            _LevelController = FindObjectOfType<LevelController>();
            _UIManager = FindObjectOfType<UIManager>();
        }

        private void StartGame()
        {
            _UIManager.SwitchScreen(true);
            _LevelController.Initialize(_saveSystem.LoadData());
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
            {
                SaveData();
            }
        }

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void SaveData()
        {
            _saveSystem.SaveData(new GameData() { BuildingData = _LevelController.GetBuildingData() });
        }
    }
}
