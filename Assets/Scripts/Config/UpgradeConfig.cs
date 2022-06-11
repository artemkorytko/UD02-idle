using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Config
{
    [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Config/UpgradeConfig")]
    public class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private AssetReference model;
        [SerializeField] private int processResult;

        public AssetReference Model => model;
        public int ProcessResult => processResult;
    }
}

