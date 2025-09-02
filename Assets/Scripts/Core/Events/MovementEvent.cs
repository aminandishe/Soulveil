namespace Core.Events
{
    public class MovementEvent
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; set; }

        public MovementEvent(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}