using System;

namespace SuperMario.Core
{
    public static class GameEvents
    {
        public static event Action OnCoinCollected;
        public static event Action OnLifeAdded;
        public static event Action<float> OnLevelResetRequested;
        public static event Action<int, int> OnLevelLoadRequested;

        public static void CoinCollected() => OnCoinCollected?.Invoke();
        public static void LifeAdded() => OnLifeAdded?.Invoke();
        public static void LevelResetRequested(float delay) => OnLevelResetRequested?.Invoke(delay);
        public static void LevelLoadRequested(int world, int stage) => OnLevelLoadRequested?.Invoke(world, stage);
    }
}
