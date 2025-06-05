using System;

namespace UnityCommonModule.InputControl.Button.Interface {
    /// <summary>
    /// ホールドに遷移することを通知するクラス
    /// </summary>
    public interface IHoldHandler {
        /// <summary>
        /// ホールドに遷移する際に発火されるイベント
        /// </summary>
        public Action ChangeHoldEvent { get; set; }
    }
}