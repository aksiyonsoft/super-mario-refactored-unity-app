using UnityEngine;

namespace SuperMario.Core
{
    public class PauseManager : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        private InputReader inputReader;

        private void Awake()
        {
            inputReader = InputReader.Instance ?? FindAnyObjectByType<InputReader>();
        }

        private void Update()
        {
            if (inputReader != null && inputReader.PausePressed) {
                TogglePause();
            }

            if (IsPaused && inputReader != null && inputReader.ResumeClicked) {
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
