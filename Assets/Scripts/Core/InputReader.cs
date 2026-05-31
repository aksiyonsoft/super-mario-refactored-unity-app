using UnityEngine;
using UnityEngine.InputSystem;

namespace SuperMario.Core
{
    public class InputReader : MonoBehaviour
    {
        public InputActionAsset inputActions;

        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction enterPipeAction;

        public float Horizontal => moveAction?.ReadValue<float>() ?? Input.GetAxis("Horizontal");
        public bool JumpPressed => jumpAction?.WasPressedThisFrame() ?? Input.GetButtonDown("Jump");
        public bool JumpHeld => jumpAction?.IsPressed() ?? Input.GetButton("Jump");
        public bool EnterPipeHeld => enterPipeAction?.IsPressed() ?? Input.GetKey(KeyCode.S);

        private void Awake()
        {
            if (inputActions == null) {
                return;
            }

            var playerMap = inputActions.FindActionMap("Player");
            moveAction = playerMap.FindAction("Move");
            jumpAction = playerMap.FindAction("Jump");
            enterPipeAction = playerMap.FindAction("EnterPipe");
        }

        private void OnEnable()
        {
            inputActions?.Enable();
        }

        private void OnDisable()
        {
            inputActions?.Disable();
        }
    }
}
