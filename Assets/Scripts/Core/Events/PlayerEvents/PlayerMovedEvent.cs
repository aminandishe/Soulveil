namespace Core.Events.PlayerEvents
{
    public class PlayerMovedEvent
    {
        public float X { get; }
        public float Y { get; }

        public PlayerMovedEvent(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}