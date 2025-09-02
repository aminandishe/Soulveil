using Core.Events;
using UnityEngine;
using Zenject;

namespace GamePlay.SandBox
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private EventBus _eventBus;

        [SerializeField] private float movementSpeed = 10f;
        
        private void Start()
        {
            _eventBus.Subscribe<MovementEvent>(playerMovedEvent =>
            {
                var xOffset = playerMovedEvent.X * movementSpeed;
                var yOffset = playerMovedEvent.Y * movementSpeed;
                
                transform.Translate(new Vector3(xOffset, 0, yOffset));
            });
        }
    }
}