using System.Collections.Generic;
using GamePlay.Models.Enemies.Abstractions;
using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(menuName = "GamePlay/Configs/WaveConfig", fileName = "WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] private List<GamePlayBaseEnemyModel> enemies;

        public List<GamePlayBaseEnemyModel> Enemies => enemies;
    }
}