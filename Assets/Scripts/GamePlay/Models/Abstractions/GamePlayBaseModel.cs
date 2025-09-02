using Core.Models.Abstractions;
using GamePlay.Components.Abstractions;
using UnityEngine;

namespace GamePlay.Models.Abstractions
{
    public abstract class GamePlayBaseModel : MonoBehaviour
    {
        protected CoreBaseModel CoreBaseModel;
        
        private void Awake()
        {
            AddComponents();
        }

        private void AddComponents()
        {
            var components = GetComponents<GamePlayBaseComponent>();
            foreach (var component in components)
            {
                var coreComponent = component.GetCoreBaseComponent();
                CoreBaseModel.AddComponent(coreComponent);
            }
        }
    }
}