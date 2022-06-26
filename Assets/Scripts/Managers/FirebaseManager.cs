using UnityEngine;
using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;

public class FirebaseManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    public async UniTask Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        await CrashlyticsInitialize();
        await AnalyticsInitialize();
    }
    
    private async UniTask AnalyticsInitialize()
    {
        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            var app = FirebaseApp.DefaultInstance;
        });
        Debug.Log($"Analytics Initialize completed");
    }

    private async UniTask CrashlyticsInitialize()
    {
        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
            }
            else
            {
                Debug.LogError(String.Format("Could not resolve all Firebase dependencies: {0}",dependencyStatus));
            }
        });   
        Debug.Log($"Crashlytics Initialize completed");
    }
    
    public async UniTask RemoteConfigBuildingsCount()
    {
        var fetchTask = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        await fetchTask.ContinueWithOnMainThread(GetBuildingsCountValue);
    }
    
    private async UniTask GetBuildingsCountValue(Task obj)
    {
        await Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync();
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue("building_amount");
        _gameManager.BuildingsCount = (int)value.LongValue;
        Debug.Log($"BuildingsCount remote config: {_gameManager.BuildingsCount}");
    }
    
    public void LevelUpEvent(string buildingName, int level)
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp, buildingName, level);
    }

    public void BuildingUnlockEvent(string buildingName)
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart, FirebaseAnalytics.ParameterLevelName, buildingName);
    }
    
    public void BuildingMaxLevelEvent(string buildingName)
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.ParameterLevel, FirebaseAnalytics.EventLevelEnd, buildingName);
    }
    
    public void AllBuildingsMaxLevelEvent()
    {
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd);
    }
}