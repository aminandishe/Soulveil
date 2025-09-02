using Core.Components;
using Core.Events;
using GamePlay.Components.Abstractions;
using UnityEngine;
using Zenject;

namespace GamePlay.Components
{
    public class GamePlayMovementComponent : GamePlayBaseComponent
    {
        private CoreMovementComponent _coreMovementComponent;

        [Inject]
        public void Construct(CoreMovementComponent coreMovementComponent)
        {
            CoreBaseComponent = coreMovementComponent;
            _coreMovementComponent = coreMovementComponent;
            _coreMovementComponent.Moved += PlayerMoved;
        }

        public void SetMovementSpeed(float movementSpeed)
        {
            _coreMovementComponent.MovementSpeed = movementSpeed;
        }

        private void PlayerMoved(MovementEvent movementEvent)
        {
            var x = movementEvent.X;
            var y = transform.position.y;
            var z = movementEvent.Y;

            transform.position = new Vector3(x, y, z);
        }
    }
}