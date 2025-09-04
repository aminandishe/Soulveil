using Core.Containers;
using GamePlay.Services;
using UnityEngine;
using Zenject;

namespace GamePlay.SandBox
{
    public class GamePlayController : MonoBehaviour
    {
        [Inject] private SystemContainer _systemContainer;
        [Inject] private DataContainer _dataContainer;
        [Inject] private EnemySpawnerService _enemySpawner;

        private void Start()
        {
            _systemContainer.Start();
            _enemySpawner.SpawnEnemies();
        }

        private void Update()
        {
            _systemContainer.Update();
            _dataContainer.Clear();
        }
    }
}