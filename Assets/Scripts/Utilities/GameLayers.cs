using UnityEngine;

namespace SuperMario.Utilities
{
    public static class GameLayers
    {
        public static int Shell { get; private set; } = -1;
        public static int Enemy { get; private set; } = -1;
        public static int PowerUp { get; private set; } = -1;

        public static void EnsureInitialized()
        {
            if (Shell >= 0) {
                return;
            }

            Shell = LayerMask.NameToLayer("Shell");
            Enemy = LayerMask.NameToLayer("Enemy");
            PowerUp = LayerMask.NameToLayer("PowerUp");
        }
    }
}
