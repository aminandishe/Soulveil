using Core.Models.Systems.Data.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GamePlay.SandBox
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Button button;
        [Inject] PlayerMovementSystemData _playerMovementSystemData;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                _playerMovementSystemData.xOffset = .5f;
                _playerMovementSystemData.yOffset = .2f; 
            });
        }
    }
}