using Core.Models.Systems.Data.Player.Abstraction;

namespace Core.Models.Systems.Data.Player
{
    public class PlayerMovementSystemData : IPlayerSystemData
    {
        public float XOffset { get; set; }
        public float YOffset { get; set; }
        
        public void Clear()
        {
            XOffset = 0;
            YOffset = 0;
        }
    }
}