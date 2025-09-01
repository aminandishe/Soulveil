using Core.Components;
using Core.Events;
using Core.Events.PlayerEvents;
using GamePlay.Components.Abstractions;
using GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace GamePlay.Components
{
    public class GamePlayMovementComponent : GamePlayBaseComponent
    {
        [Inject] private readonly EventBus _eventBus;
        [Inject] private readonly PlayerMovementConfig _playerMovementConfig;

        private void Awake()
        {
            CoreBaseComponent = new CoreMovementComponent();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void Start()
        {
            ((CoreMovementComponent)CoreBaseComponent).MoveSpeed = _playerMovementConfig.MoveSpeed;
        }

        private void AddListeners()
        {
            _eventBus.Subscribe<PlayerMovedEvent>(PlayerMoved);
        }

        private void PlayerMoved(PlayerMovedEvent playerMovedEvent)
        {
            var x = playerMovedEvent.X;
            var y = transform.position.y;
            var z = playerMovedEvent.Y;

            transform.position = new Vector3(x, y, z);
        }
    }
}