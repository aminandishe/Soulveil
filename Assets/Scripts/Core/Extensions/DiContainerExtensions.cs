using Core.Containers;
using Core.Events;
using Zenject;

namespace Core.Extensions
{
    public static class DiContainerExtensions
    {
        public static void InstallCore(this DiContainer container)
        {
            BindContainers(container);
            BindEvents(container);
        }

        private static void BindContainers(DiContainer container)
        {
            container.Bind<DataContainer>().AsSingle();
            container.Bind<SystemContainer>().AsSingle();
        }

        private static void BindEvents(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<EventBus>();
        }
    }
}