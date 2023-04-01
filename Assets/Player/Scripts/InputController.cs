using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SH.Player
{
    [CreateAssetMenu(menuName = "InputController")]
    internal class InputController : ScriptableObject, GameInput.IGameplayActions
    {
        private GameInput _gameInput;

        private void OnEnable()
        {
            if(_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Gameplay.SetCallbacks(this);
                _gameInput.Gameplay.Enable();
            }
        }
        public event Action<float> MoveEvent;
        public event Action JumpEvent;
        public event Action CreateHookEvent;
        public event Action DisableHookEvent;

        public void OnHook(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                CreateHookEvent?.Invoke();
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                DisableHookEvent?.Invoke();
            }
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(_gameInput.Gameplay.Move.ReadValue<float>());
        }
    }
}
