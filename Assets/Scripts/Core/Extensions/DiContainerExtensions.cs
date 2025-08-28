using Core.Containers;
using Core.Events;
using Core.Models.Systems.Data.Player;
using Core.Systems.Abstractions;
using Core.Systems.Player;
using Zenject;

namespace Core.Extensions
{
    public static class DiContainerExtensions
    {
        public static void InstallCore(this DiContainer container)
        {
            BindContainers(container);
            BindSystems(container);
            BindSystemData(container);
            BindEvents(container);
        }

        private static void BindContainers(DiContainer container)
        {
            container.Bind<DataContainer>().AsSingle();
            container.Bind<SystemContainer>().AsSingle();
        }

        private static void BindSystems(DiContainer container)
        {
            container.Bind<GeneralSystem>().To<PlayerMovementGeneralSystem>().AsSingle();
        }
        
        private static void BindSystemData(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<PlayerMovementSystemData>().AsSingle();    
        }

        private static void BindEvents(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<EventBus>().AsSingle();
        }
    }
}