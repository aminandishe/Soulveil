using Core.Components.Abstractions;

namespace Core.Components
{
    public class CoreMovementComponent : CoreBaseComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float MoveSpeed { get; set; }
    }
}