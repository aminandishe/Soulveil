using GamePlay.Configs;
using UnityEngine;

namespace GamePlay.Handlers
{
    public class PlayerMovementConfigHandler
    {
        private PlayerMovementConfig _playerMovementConfig;

        public PlayerMovementConfigHandler()
        {
            LoadFromAssets();
        }

        private void LoadFromAssets()
        {
            _playerMovementConfig = Resources.Load<PlayerMovementConfig>("Configs/PlayerMovementConfig");
        }

        public float GetMovementSpeed()
        {
            return _playerMovementConfig.MoveSpeed;
        }
    }
}