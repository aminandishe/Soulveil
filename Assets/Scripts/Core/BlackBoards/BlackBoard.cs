using System.Collections;
using System.Collections.Generic;
using Core.Models.Systems.Data.Abstractions;

namespace Core.BlackBoards
{
    public class BlackBoard<T> : IEnumerable<T> where T : ISystemModel
    {
        private readonly List<T> _dataList;

        public BlackBoard(IEnumerable<T> models)
        {
            _dataList = new List<T>(models);
        }

        public void Add(T data)
        {
            _dataList.Add(data);
        }

        public void Clear()
        {
            foreach (var t in _dataList)
            {
                t.Clear();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dataList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}