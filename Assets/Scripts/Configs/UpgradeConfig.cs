using UnityEngine;

namespace MyNamespace.Configs
{
    [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Config/PointUpgradeConfig", order = 0)]
    public class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private GameObject model;
        [SerializeField] private int income;
        public GameObject Model => model;
        public int Income => income;

    }
}