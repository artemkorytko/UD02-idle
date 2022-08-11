using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace.Configs
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Configs/LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private int money;
        [SerializeField] private List<Point> points;
    }
}