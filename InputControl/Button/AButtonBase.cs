using System;
using UnityCommonModule.InputControl.Interface;
using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Button {
    [Serializable]
    public class AButtonBase : IInputReceiver {


        public void OnInput(InputAction.CallbackContext context) {
            
            if (context.performed) {
                
            }

            if (context.canceled) {
                
            }
        }
    }
}