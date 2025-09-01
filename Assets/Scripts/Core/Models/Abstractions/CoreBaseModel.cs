using System.Collections.Generic;
using Core.Components.Abstractions;

namespace Core.Models.Abstractions
{
    public abstract class CoreBaseModel
    {
        private readonly List<CoreBaseComponent> _components = new();

        public void AddComponent(CoreBaseComponent component)
        {
            _components.Add(component);
        }

        public T GetComponent<T>() where T : CoreBaseComponent
        {
            foreach (var component in _components)
            {
                if (component is T foundedComponent)
                {
                    return foundedComponent;
                }
            }

            return null;
        }

        public List<CoreBaseComponent> GetAllComponents()
        {
            return _components;
        }
    }
}