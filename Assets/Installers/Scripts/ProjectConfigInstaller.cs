using MyNamespace.Configs;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "ProjectConfigInstaller", menuName = "Installers/ProjectConfigInstaller")]
    public class ProjectConfigInstaller : ScriptableObjectInstaller<ProjectConfigInstaller>
    {
        [SerializeField] private ProjectConfig config;
        
        
        
        public override void InstallBindings()
        {
            Container.BindInstance(config);
        }
    }
}