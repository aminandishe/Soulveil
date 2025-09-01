using Core.Containers;
using UnityEngine;
using Zenject;

namespace GamePlay.SandBox
{
    public class GamePlayController : MonoBehaviour
    {
        [Inject] private SystemContainer _systemContainer;
        [Inject] private DataContainer _dataContainer;

        private void Start()
        {
            _systemContainer.Start();
        }

        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Clear();
        }
    }
}