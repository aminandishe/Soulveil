using UnityEngine;

namespace GamePlay.Configs
{
    [CreateAssetMenu(menuName = "GamePlay/Configs/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float movementSpeed;

        public float MovementSpeed => movementSpeed;
    }
}