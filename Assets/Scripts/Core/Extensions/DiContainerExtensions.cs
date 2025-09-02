using Core.Components;
using Core.Containers;
using Core.Events;
using Core.Models.Enemies;
using Core.Models.Players;
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
            BindModels(container);
            BindComponents(container);
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

        private static void BindModels(DiContainer container)
        {
            container.Bind<CorePlayerModel>().AsSingle();
            container.Bind<CoreNormalEnemy>().AsTransient();
        }

        private static void BindComponents(DiContainer container)
        {
            container.Bind<CoreMovementComponent>().AsTransient();
        }
    }
}