using UnityEngine;
using UnityEngine.InputSystem;

namespace SuperMario.Core
{
    [DefaultExecutionOrder(-50)]
    public class InputReader : MonoBehaviour
    {
        public static InputReader Instance { get; private set; }

        public InputActionAsset inputActions;

        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction enterPipeAction;
        private InputAction pauseAction;

        public float Horizontal => moveAction?.ReadValue<float>() ?? 0f;
        public bool JumpPressed => jumpAction?.WasPressedThisFrame() ?? false;
        public bool JumpHeld => jumpAction?.IsPressed() ?? false;
        public bool EnterPipeHeld => enterPipeAction?.IsPressed() ?? false;
        public bool PausePressed => pauseAction?.WasPressedThisFrame() ?? false;

        public bool ResumeClicked =>
            Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        private void Awake()
        {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            if (inputActions == null) {
                Debug.LogError("InputReader: PlayerControls InputActionAsset is not assigned.");
                return;
            }

            var playerMap = inputActions.FindActionMap("Player");
            var gameMap = inputActions.FindActionMap("Game");

            moveAction = playerMap.FindAction("Move");
            jumpAction = playerMap.FindAction("Jump");
            enterPipeAction = playerMap.FindAction("EnterPipe");
            pauseAction = gameMap.FindAction("Pause");
        }

        private void OnEnable()
        {
            inputActions?.Enable();
        }

        private void OnDisable()
        {
            inputActions?.Disable();
        }

        private void OnDestroy()
        {
            if (Instance == this) {
                Instance = null;
            }
        }
    }
}
