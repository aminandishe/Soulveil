using Core.Extensions;
using GamePlay.Handlers;
using Zenject;

namespace GamePlay.Installers
{
    public class GamePlayInstaller : MonoInstaller<GamePlayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();

            Container.Bind<PlayerMovementConfigHandler>().AsSingle();
        }
    }
}