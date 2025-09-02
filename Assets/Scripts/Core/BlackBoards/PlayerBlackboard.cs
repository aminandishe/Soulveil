using System.Collections.Generic;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Player.Abstraction;

namespace Core.BlackBoards
{
    public class PlayerBlackboard : BlackBoard<ISystemData>
    {
        public PlayerBlackboard(IEnumerable<IPlayerSystemData> playerSystemData) : base(playerSystemData)
        {
        }
    }
}