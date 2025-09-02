using System.Collections.Generic;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Enemy.Abstractions;

namespace Core.BlackBoards
{
    public class EnemyBlackboard : BlackBoard<ISystemData>
    {
        public EnemyBlackboard(IEnumerable<IEnemySystemData> enemySystemData) : base(enemySystemData)
        {
        }
    }
}