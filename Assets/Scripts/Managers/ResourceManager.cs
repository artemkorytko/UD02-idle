using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

public class ResourceManager : MonoBehaviour
{
   // [SerializeField] private GameObject prefabs;
    //[SerializeField] private ResourceContainer container;
    [SerializeField] private AssetReference prefab;

    private GameObject _instance;

    private async void Start()
    {
        //Instantiate(prefabs);
        //Instantiate(container.Prefab);
        _instance = await Addressables.InstantiateAsync(prefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Addressables.ReleaseInstance(_instance);
        }
    }
}
