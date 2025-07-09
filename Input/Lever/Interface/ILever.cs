using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.Input.Leber.Interface {
    public interface ILever {
        
        public Vector2 Pos { get; }
        
        public void OnInput (InputAction.CallbackContext context);
    }
}