using MyNamespace;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GamePrefabsInstaller : MonoInstaller
    {
        //позволяет быть на сцене как обычный игровой объект
        //мы можем передавать игровые объекты сюда

        [SerializeField] private UIManager uiManager; 
        //[SerializeField] private LevelComponent levelComponent;
        //[SerializeField] private AudioManager uiManager; //TODO

        
        
        public override void InstallBindings()
        {
            Container.BindInstance(uiManager);
            //Container.BindInstance(levelComponent);  // не один, т.к. гипотетически уровней может быть много
        }
    }
}