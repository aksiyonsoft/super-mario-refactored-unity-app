using UnityEngine;

namespace SuperMario.Core
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Super Mario/Game Config")]
    public class GameConfig : ScriptableObject
    {
        public int initialLives = 3;
        public int coinsPerLife = 100;
        public int targetFrameRate = 60;
    }
}
