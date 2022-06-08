using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Managers
{
    public class ResourcesManager : MonoBehaviour
    {
        [SerializeField] private GameObject prefabs;
        [SerializeField] private ResourcesContainer container;

        [SerializeField] private string prefabPath;

        //[SerializeField] private GameObject prefab;
        [SerializeField] private AssetReference prefab;

        private GameObject _instance;

        private async void Start()
        {
            // Instantiate(prefabs);
            // Instantiate(container.Prefab);
            // Instantiate(Resources.Load(prefabPath));

            //Instantiate(prefab.Asset);

            _instance = await Addressables.InstantiateAsync("prefab");
            await Addressables.LoadSceneAsync("Game");
            var list = await  Addressables.LoadAssetsAsync<GameObject>("Level 2", x => { });
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Addressables.ReleaseInstance(_instance);
            }
            
        }
    }
}