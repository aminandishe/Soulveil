using GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace GamePlay.Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(playerConfig).AsSingle();
        }
    }
}