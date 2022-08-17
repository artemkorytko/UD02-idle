using UnityEngine;

namespace MyNamespace.Configs
{
    [CreateAssetMenu(fileName = "ProjectConfig", menuName = "Configs/ProjectConfig", order = 0)]
    public class ProjectConfig : ScriptableObject
    {
        //всё для проекта, что-то совсем глобальное
        [SerializeField] private int targetFPS;
        [SerializeField] private bool isMultyTouch;

        public int TargetFPS => targetFPS;

        public bool IsMultyTouch => isMultyTouch;
        
        //мб громкость звука сделать
    }
}