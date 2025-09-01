using Core.Extensions;
using Zenject;

namespace GamePlay.Installers
{
    public class GamePlayInstaller : MonoInstaller<GamePlayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();
        }
    }
}