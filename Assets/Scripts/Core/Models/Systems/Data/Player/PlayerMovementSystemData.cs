using Core.Models.Systems.Data.Player.Abstraction;

namespace Core.Models.Systems.Data.Player
{
    public class PlayerMovementSystemData : IPlayerSystemData
    {
        public float xOffset { get; set; }
        public float yOffset { get; set; }
        
        public void Clear()
        {
            xOffset = 0;
            yOffset = 0;
        }
    }
}