using UnityEngine;
using UnityEngine.InputSystem;

namespace SuperMario.Core
{
    [DefaultExecutionOrder(-50)]
    public class InputReader : MonoBehaviour
    {
        public static InputReader Instance { get; private set; }

        private InputActionAsset inputActions;
        private bool ownsInputActions;

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
            CreateInputActions();
        }

        private void CreateInputActions()
        {
            inputActions = ScriptableObject.CreateInstance<InputActionAsset>();
            ownsInputActions = true;

            var playerMap = inputActions.AddActionMap("Player");

            moveAction = playerMap.AddAction("Move", InputActionType.Value);
            moveAction.AddCompositeBinding("1DAxis")
                .With("Negative", "<Keyboard>/a")
                .With("Positive", "<Keyboard>/d");
            moveAction.AddCompositeBinding("1DAxis")
                .With("Negative", "<Keyboard>/leftArrow")
                .With("Positive", "<Keyboard>/rightArrow");

            jumpAction = playerMap.AddAction("Jump", InputActionType.Button);
            jumpAction.AddBinding("<Keyboard>/space");
            jumpAction.AddBinding("<Keyboard>/w");
            jumpAction.AddBinding("<Keyboard>/upArrow");

            enterPipeAction = playerMap.AddAction("EnterPipe", InputActionType.Button);
            enterPipeAction.AddBinding("<Keyboard>/s");

            var gameMap = inputActions.AddActionMap("Game");
            pauseAction = gameMap.AddAction("Pause", InputActionType.Button);
            pauseAction.AddBinding("<Keyboard>/escape");
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

            if (ownsInputActions && inputActions != null) {
                Destroy(inputActions);
            }
        }
    }
}
