using System.Linq;
using Core.BlackBoards;
using Core.Models.Systems.Data.Abstractions;

namespace Core.Containers
{
    public class DataContainer
    {
        private readonly BlackBoard<ISystemData> _frameBaseBlackBoard;

        public DataContainer(
            ISystemData[] systemData)
        {
            _frameBaseBlackBoard = new BlackBoard<ISystemData>(systemData);
        }

        public void Clear()
        {
            _frameBaseBlackBoard.Clear();
        }

        public T GetData<T>() where T : ISystemData
        {
            var result = _frameBaseBlackBoard.FirstOrDefault(data => data.GetType() == typeof(T));
            if (result != default)
                return (T)result;

            return default;
        }
    }
}