using SuperMario.Core;
using SuperMario.Player;
using UnityEngine;

namespace SuperMario.Collectibles
{
    public class PowerUp : MonoBehaviour
    {
        public enum Type
        {
            Coin,
            ExtraLife,
            MagicMushroom,
            Starpower,
        }

        public Type type;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent(out Player player)) {
                Collect(player);
            }
        }

        private void Collect(Player player)
        {
            switch (type)
            {
                case Type.Coin:
                    GameEvents.CoinCollected();
                    break;

                case Type.ExtraLife:
                    GameEvents.LifeAdded();
                    break;

                case Type.MagicMushroom:
                    player.Grow();
                    break;

                case Type.Starpower:
                    player.Starpower();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
