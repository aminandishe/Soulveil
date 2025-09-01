using GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace GamePlay.Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private PlayerMovementConfig playerMovementConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerMovementConfig>().FromInstance(playerMovementConfig).AsSingle();
        }
    }
}