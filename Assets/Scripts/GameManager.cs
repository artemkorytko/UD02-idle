using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private SaveSystem _saveSystem;
        private LevelController _levelController;
        private UIManager _UIManager;
        public static GameManager Instance = null;

        private float _money = 60;
        public System.Action<float> OnMoneyValueChange = null;

        public float Money
        {
            get
            {
                return _money;
            }

            set
            {
                if (value >= 0)
                {
                    _money = value;
                    _money = (float) System.Math.Round(_money, 2);
                    OnMoneyValueChange?.Invoke(_money);
                }
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            _saveSystem = FindObjectOfType<SaveSystem>();
            _levelController = FindObjectOfType<LevelController>();
            _UIManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            StartGame();
            Crash();
        }

        private void Crash()
        {
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
                }
                else
                {
                    Debug.LogError(String.Format(
                        "Could not resolve all Firebase dependencies: {0}",dependencyStatus));
                }
            });
        }

        private async void StartGame()
        {
            //await FetchDataAsync();
            AnalyticsStartGame();
            _UIManager.SwitchScreen(true);
            _levelController.Initialize(await  _saveSystem.LoadData());
            //_LevelController.Initialize(_saveSystem.LoadData());
        }

        // private async UniTask<int> FetchDataAsync()
        // {
        //     Task fetchTask = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync((TimeSpan.Zero));
        //     await fetchTask.ContinueWithOnMainThread(CheckValue);
        //     return CheckValue(fetchTask.ContinueWithOnMainThread(CheckValue));
        // }

        private async UniTask<int> CheckValue(Task obj)
        {
            await Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
            var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("building_amount");
            return (int) value.LongValue;
        }
        
        //Я пытался... :) 
        private void AnalyticsStartGame()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
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
            _saveSystem.SaveData(new GameData()); /*{ BuildingData = _levelController.GetBuildingData() })*/;
        }
    }
}
