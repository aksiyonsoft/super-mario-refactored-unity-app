using SuperMario.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SuperMario.UI
{
    public class HUDController : MonoBehaviour
    {
        public Text livesText;
        public Text coinsText;

        private void OnEnable()
        {
            GameEvents.OnCoinCollected += Refresh;
            GameEvents.OnLifeAdded += Refresh;
        }

        private void OnDisable()
        {
            GameEvents.OnCoinCollected -= Refresh;
            GameEvents.OnLifeAdded -= Refresh;
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            if (GameManager.Instance == null) {
                return;
            }

            if (livesText != null) {
                livesText.text = $"x{GameManager.Instance.lives}";
            }

            if (coinsText != null) {
                coinsText.text = $"x{GameManager.Instance.coins:00}";
            }
        }
    }
}
