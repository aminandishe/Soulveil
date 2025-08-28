using System.Collections.Generic;
using System.Linq;
using Core.Models.Systems.Data.Abstractions;
using Core.Models.Systems.Data.Player.Abstraction;
using UnityEngine;

namespace Core.BlackBoards
{
    public class PlayerBlackboard : BlackBoard<ISystemData>
    {
        public PlayerBlackboard(IEnumerable<IPlayerSystemData> playerSystemData) : base(playerSystemData)
        {
            Debug.Log(playerSystemData.ToList().Count);
        }
    }
}