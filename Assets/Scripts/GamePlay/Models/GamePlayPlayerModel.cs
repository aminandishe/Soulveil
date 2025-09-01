using Core.Models;
using GamePlay.Components.Abstractions;
using GamePlay.Models.Abstractions;
using Zenject;

namespace GamePlay.Models
{
    public class GamePlayPlayerModel : GamePlayBaseModel
    {
        [Inject] private CorePlayerModel _corePlayerModel;
        private void Awake()
        {
            CoreBaseModel = _corePlayerModel;
        }

        private void Start()
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