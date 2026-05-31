using UnityEngine;

namespace SuperMario.Core
{
    public class PauseManager : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                TogglePause();
            }

            if (IsPaused && Input.GetMouseButtonDown(0)) {
                Resume();
            }
        }

        public void TogglePause()
        {
            if (IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }

        private void OnDestroy()
        {
            if (IsPaused) {
                Time.timeScale = 1f;
                IsPaused = false;
            }
        }
    }
}
