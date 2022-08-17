using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameSceneConfigInstaller", menuName = "Installers/GameSceneConfigInstaller")]
    public class GameSceneConfigsInstaller : ScriptableObjectInstaller<GameSceneConfigsInstaller>
    {
        //[SerializeField] private LevelSettings config;
        //[SerializeField] private PointSettings pointSettings;

        
        
        // public override void InstallBindings()
        // {
               //Container.BindInstance(pointSettings);
        // }
    }
}