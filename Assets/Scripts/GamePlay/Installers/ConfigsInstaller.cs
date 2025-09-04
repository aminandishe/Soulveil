using System.Collections.Generic;
using GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace GamePlay.Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private WaveConfig waveConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(playerConfig).AsSingle();
            Container.Bind<WaveConfig>().FromInstance(waveConfig).AsSingle();
        }
    }
}