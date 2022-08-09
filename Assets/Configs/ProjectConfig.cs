using UnityEngine;

namespace Installers.Configs
{
    [CreateAssetMenu(fileName = "ProjectConfig", menuName = "Configs/ProjectConfig", order = 0)]
    public class ProjectConfig : ScriptableObject
    {
        [SerializeField] private int targetFps;
        [SerializeField] private bool isMultiTouch;

        public int TargetFps
        {
            get => targetFps;
            set => targetFps = value;
        }

        public bool IsMultiTouch
        {
            get => isMultiTouch;
            set => isMultiTouch = value;
        }
    }
}