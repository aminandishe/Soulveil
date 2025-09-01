using Core.Components.Abstractions;
using UnityEngine;

namespace GamePlay.Components.Abstractions
{
    public abstract class GamePlayBaseComponent : MonoBehaviour
    {
        protected CoreBaseComponent CoreBaseComponent;

        public CoreBaseComponent GetCoreBaseComponent()
        {
            return CoreBaseComponent;
        }
    }
}