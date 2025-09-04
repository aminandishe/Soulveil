using Core.Models.Enemies;
using GamePlay.Models.Enemies.Abstractions;
using Zenject;

namespace GamePlay.Models.Enemies
{
    public class GamePlayNormalEnemyModel : GamePlayBaseEnemyModel
    {
        [Inject]
        public void Construct(CoreNormalEnemy coreNormalEnemy)
        {
            CoreBaseModel = coreNormalEnemy;
        }
    }
}