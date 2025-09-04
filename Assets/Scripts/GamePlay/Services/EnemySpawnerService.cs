using System.Collections.Generic;
using System.Linq;
using GamePlay.Configs;
using UnityEngine;
using Zenject;

namespace GamePlay.Services
{
    public class EnemySpawnerService
    {
        private readonly List<WaveConfig> _waveConfig;
        private readonly DiContainer _container;

        public EnemySpawnerService(IEnumerable<WaveConfig> waveConfig, DiContainer container)
        {
            _waveConfig = waveConfig.ToList();
            _container = container;
        }

        public void SpawnEnemies()
        {
            foreach (var enemyModel in _waveConfig[0].Enemies)
            {
                var enemy = _container.InstantiatePrefab(enemyModel);
                var x = Random.Range(-4, 4);
                var z = Random.Range(3, 17);
                enemy.transform.position = new Vector3(x, 0, z);
            }
        }
    }
}