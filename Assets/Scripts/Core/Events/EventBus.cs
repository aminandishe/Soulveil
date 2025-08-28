using System;
using System.Collections.Generic;
using Core.Events.Abstractions;

namespace Core.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public void Publish<T>(T evt)
        {
            if (_subscribers.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var handler in handlers)
                    ((Action<T>)handler)?.Invoke(evt);
            }
        }

        public void Subscribe<T>(Action<T> handler)
        {
            if (!_subscribers.ContainsKey(typeof(T)))
                _subscribers[typeof(T)] = new List<Delegate>();

            _subscribers[typeof(T)].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            if (_subscribers.TryGetValue(typeof(T), out var handlers))
                handlers.Remove(handler);
        }
    }
}