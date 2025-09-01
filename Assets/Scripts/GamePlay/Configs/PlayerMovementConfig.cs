using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(menuName = "GamePlay/Configs/PlayerMovementConfig", fileName = "PlayerMovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [SerializeField] private float moveSpeed;

        public float MoveSpeed => moveSpeed;
    }
}