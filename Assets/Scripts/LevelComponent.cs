using MyNamespace.Configs;
using UnityEngine;
using Zenject;

namespace MyNamespace
{
    //компонент для левела, с конструктором для Zenject
    public class LevelComponent : MonoBehaviour
    {
        private LevelSettings _levelSettings;
        
        [Inject] //вкололи герыч
        public void Construct(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
        }

        // private void Awake()
        // {
        //     Debug.Log("Всё работает" + _levelSettings.Money);
        // }
    }
}