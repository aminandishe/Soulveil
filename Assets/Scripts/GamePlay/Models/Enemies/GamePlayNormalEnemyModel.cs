using Core.Models.Enemies;
using GamePlay.Models.Abstractions;
using Zenject;

namespace GamePlay.Models.Enemies
{
    public class GamePlayNormalEnemyModel : GamePlayBaseModel
    {
        [Inject]
        public void Construct(CoreNormalEnemy coreNormalEnemy)
        {
            CoreBaseModel = coreNormalEnemy;
        }
    }
}