using System;
using Core.Components.Abstractions;
using Core.Events;

namespace Core.Components
{
    public class CoreMovementComponent : CoreBaseComponent
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float MovementSpeed { get; set; }
        public event Action<MovementEvent> Moved;

        public void RaiseMoved()
        {
            Moved?.Invoke(new MovementEvent(X, Y, Z));
        }
    }
}