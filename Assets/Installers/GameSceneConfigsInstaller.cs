using Installers.Configs;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSceneConfig", menuName = "Installers/GameSceneConfig")]
public class GameSceneConfigsInstaller : ScriptableObjectInstaller<GameSceneConfigsInstaller>
{
    [SerializeField]  private PlayerSettings playerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(playerSettings);
    }
}