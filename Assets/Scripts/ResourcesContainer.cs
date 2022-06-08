using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ResourcesContainer", menuName = "Config/ResourcesContainer", order = 0)]
    public class ResourcesContainer : ScriptableObject
    {
        [SerializeField] private AssetReference prefab;

        public AssetReference Prefab => prefab;
    }
}