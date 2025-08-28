using Core.BlackBoards;
using Core.Containers;
using Core.Events;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Player;
using Zenject;

namespace Core.Extensions
{
    public static class DiContainerExtensions
    {
        public static void InstallCore(this DiContainer container)
        {
            BindContainers(container);
            BindBlackboards(container);
            BindSystemData(container);
            BindEvents(container);
        }

        private static void BindContainers(DiContainer container)
        {
            container.Bind<DataContainer>().AsSingle();
            container.Bind<SystemContainer>().AsSingle();
        }

        private static void BindBlackboards(DiContainer container)
        {
            container.Bind<PlayerBlackboard>().AsSingle();
        }
        
        private static void BindSystemData(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<PlayerMovementSystemData>().AsSingle();    
        }

        private static void BindEvents(DiContainer container)
        {
            container.BindInterfacesAndSelfTo<EventBus>();
        }
    }
}