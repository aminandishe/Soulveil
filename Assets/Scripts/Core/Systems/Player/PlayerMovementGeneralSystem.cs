using System;
using Core.Components;
using Core.Models;
using Core.Models.Systems.Data.Player;
using Core.Systems.Abstractions;

namespace Core.Systems.Player
{
    public class PlayerMovementGeneralSystem : GeneralSystem
    {
        private readonly PlayerMovementSystemData _playerMovementSystemData;
        private readonly CorePlayerModel _corePlayerModel;

        public PlayerMovementGeneralSystem(PlayerMovementSystemData playerMovementSystemData,
            CorePlayerModel corePlayerModel)
        {
            _playerMovementSystemData = playerMovementSystemData;
            _corePlayerModel = corePlayerModel;
        }

        public override void Update()
        {
            var xOffset = _playerMovementSystemData.XOffset;
            var yOffset = _playerMovementSystemData.YOffset;

            if (xOffset == 0 || yOffset == 0)
                return;

            var movementComponent = _corePlayerModel.GetComponent<CoreMovementComponent>();
            if (movementComponent == null)
                throw new Exception("CoreMovementComponent is null");

            movementComponent.X += xOffset * movementComponent.MovementSpeed;
            movementComponent.Y += yOffset * movementComponent.MovementSpeed;
            movementComponent.RaiseMoved();
        }
    }
}