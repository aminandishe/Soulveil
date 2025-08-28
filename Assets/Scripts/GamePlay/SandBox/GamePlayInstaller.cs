using Core.Extensions;
using Zenject;

namespace GamePlay.SandBox
{
    public class GamePlayInstaller : MonoInstaller<GamePlayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();
        }
    }
}