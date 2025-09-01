using Core.Models;
using GamePlay.Components.Abstractions;
using GamePlay.Models.Abstractions;
using Zenject;

namespace GamePlay.Models
{
    public class GamePlayPlayerModel : GamePlayBaseModel
    {
        
        [Inject]
        public void Construct(CorePlayerModel corePlayerModel)
        {
            CoreBaseModel = corePlayerModel;
            
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