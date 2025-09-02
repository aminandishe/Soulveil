using System.Linq;
using Core.BlackBoards;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Enemy.Abstractions;
using Core.Models.Systems.Data.Player.Abstraction;

namespace Core.Containers
{
    public class DataContainer
    {
        private readonly PlayerBlackboard _playerBlackboard;
        private readonly EnemyBlackboard _enemyBlackboard;

        public DataContainer(IPlayerSystemData[] playerSystemData, IEnemySystemData[] enemySystemData)
        {
            _playerBlackboard = new PlayerBlackboard(playerSystemData);
            _enemyBlackboard = new EnemyBlackboard(enemySystemData);
        }

        public void Clear()
        {
            _playerBlackboard.Clear();
            _enemyBlackboard.Clear();
        }

        public T GetData<T>() where T : ISystemData
        {
            var result = _playerBlackboard.FirstOrDefault(data => data.GetType() == typeof(T));
            if (result != default)
                return (T)result;

            return default;
        }
    }
}