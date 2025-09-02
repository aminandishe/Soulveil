using Core.Models;
using GamePlay.Components;
using GamePlay.Components.Abstractions;
using GamePlay.Configs;
using GamePlay.Models.Abstractions;
using Zenject;

namespace GamePlay.Models
{
    public class GamePlayPlayerModel : GamePlayBaseModel
    {
        [Inject]
        public void Construct(CorePlayerModel corePlayerModel, PlayerConfig playerConfig)
        {
            CoreBaseModel = corePlayerModel;

            AddComponents();
            InitConfig(playerConfig);
        }

        private void AddComponents()
        {
            var components = GetComponents<GamePlayBaseComponent>();
            foreach (var component in components)
            {
                var coreComponent = component.GetCoreBaseComponent();
                CoreBaseModel.AddComponent(coreComponent);
            }
        }

        private void InitConfig(PlayerConfig playerConfig)
        {
            var movementComponent = GetComponent<GamePlayMovementComponent>();
            movementComponent?.SetMovementSpeed(playerConfig.MovementSpeed);
        }
    }
}