using Core.Containers;
using Zenject;

namespace Core.Extensions
{
    public static class DiContainerExtensions
    {
        public static void InstallCore(this DiContainer container)
        {
            BindContainers(container);
        }

        private static void BindContainers(DiContainer container)
        {
            container.Bind<DataContainer>().AsSingle();
            container.Bind<SystemContainer>().AsSingle();
        }
    }
}