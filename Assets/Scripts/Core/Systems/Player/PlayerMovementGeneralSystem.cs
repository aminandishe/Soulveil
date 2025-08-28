using Core.Events;
using Core.Events.PlayerEvents;
using Core.Models.Systems.Data.Player;
using Core.Systems.Abstractions;

namespace Core.Systems.Player
{
    public class PlayerMovementGeneralSystem : GeneralSystem
    {
        private readonly EventBus _eventBus;
        private readonly PlayerMovementSystemData _playerMovementSystemData;

        public PlayerMovementGeneralSystem(EventBus eventBus, PlayerMovementSystemData playerMovementSystemData)
        {
            _eventBus = eventBus;
            _playerMovementSystemData = playerMovementSystemData;
        }

        public override void Update()
        {
            var xOffset = _playerMovementSystemData.xOffset;
            var yOffset = _playerMovementSystemData.yOffset;

            if (xOffset == 0 || yOffset == 0)
                return;

            _eventBus.Publish(new PlayerMovedEvent(xOffset, yOffset));
        }
    }
}