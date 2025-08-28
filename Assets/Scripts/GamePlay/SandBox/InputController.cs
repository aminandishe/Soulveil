using Core.BlackBoards;
using UnityEngine;
using Zenject;

namespace GamePlay.SandBox
{
    public class InputController : MonoBehaviour
    {
        [Inject] private PlayerBlackboard _playerBlackboard;
        private void Start()
        {
            Debug.Log(_playerBlackboard);
        }
    }
}