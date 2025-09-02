using Core.Models.Players;
using GamePlay.Models.Abstractions;
using Zenject;

namespace GamePlay.Models
{
    public class GamePlayPlayerModel : GamePlayBaseModel
    {
        
        [Inject]
        public void Construct(CorePlayerModel corePlayerModel)
        {
            CoreBaseModel = corePlayerModel;
        }
    }
}