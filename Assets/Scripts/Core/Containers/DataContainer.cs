using System.Linq;
using Core.BlackBoards;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Player.Abstraction;

namespace Core.Containers
{
    public class DataContainer
    {
        private readonly PlayerBlackboard _playerBlackboard;

        public DataContainer(
            IPlayerSystemData[] systemData)
        {
            _playerBlackboard = new PlayerBlackboard(systemData);
        }

        public void Clear()
        {
            _playerBlackboard.Clear();
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