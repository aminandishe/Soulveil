using Core.Models.Systems.Data.Player;
using GamePlay.Handlers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GamePlay.Controllers
{
    public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [Inject] private readonly PlayerMovementConfigHandler _playerMovementConfigHandler;
        
        [SerializeField] private RectTransform handle;
        [SerializeField] private float handleRange = 100f;

        private RectTransform _background;
        private Vector2 _input = Vector2.zero;

        [Inject] private PlayerMovementSystemData _movementData;

        private void Awake()
        {
            _background = GetComponent<RectTransform>();
            if (handle == null)
                Debug.LogError("Handle is not assigned to VirtualJoystick!");
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _background, eventData.position, eventData.pressEventCamera, out pos
            );

            pos = Vector2.ClampMagnitude(pos, handleRange);
            handle.anchoredPosition = pos;
            _input = pos / handleRange;
        }

        public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

        public void OnPointerUp(PointerEventData eventData)
        {
            handle.anchoredPosition = Vector2.zero;
            _input = Vector2.zero;
        }

        private void Update()
        {
            // Write to PlayerMovementSystemData
            _movementData.XOffset = _input.x;
            _movementData.YOffset = _input.y;
        }
    }
}