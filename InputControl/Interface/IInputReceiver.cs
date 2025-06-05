using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Interface {
    /// <summary>
    /// InputSystemから入力情報を受け取るクラスに対して約束するインターフェース
    /// </summary>
    public interface IInputReceiver {
        public void OnInput (InputAction.CallbackContext context);
    }
}