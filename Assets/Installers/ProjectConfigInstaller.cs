using Installers.Configs;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UntitledInstaller", menuName = "Installers/UntitledInstaller")]
public class ProjectConfigInstaller : ScriptableObjectInstaller<ProjectConfigInstaller>
{
    [SerializeField] private ProjectConfig projectConfig;
    
    public override void InstallBindings()
    {
        // cоздаём ссылку для конфига
        Container.BindInstance(projectConfig);
    }
}

// bind - передача внутрь контейнера