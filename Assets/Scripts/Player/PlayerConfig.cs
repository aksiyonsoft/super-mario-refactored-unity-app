using UnityEngine;

namespace SuperMario.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Super Mario/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        public float moveSpeed = 8f;
        public float maxJumpHeight = 5f;
        public float maxJumpTime = 1f;
    }
}
