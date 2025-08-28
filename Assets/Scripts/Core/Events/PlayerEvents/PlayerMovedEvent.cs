namespace Core.Events.PlayerEvents
{
    public class PlayerMovedEvent
    {
        public float xOffset { get; }
        public float yOffset { get; }

        public PlayerMovedEvent(float xOffset, float yOffset)
        {
            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }
    }
}