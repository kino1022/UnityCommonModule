using System;
using UnityCommonModule.InputControl.Button.Definition;

namespace UnityCommonModule.InputControl.Button.Interface {
    /// <summary>
    /// ボタンの押下情報変化を通知するクラスに対して約束するインターフェース
    /// </summary>
    public interface IChangeSituationHandler {
        /// <summary>
        /// ボタンの入力状態が変化した際に発火されるイベント
        /// </summary>
        public Action<ButtonSituation> ChangeSituationEvent { get; set; }
    }
}

