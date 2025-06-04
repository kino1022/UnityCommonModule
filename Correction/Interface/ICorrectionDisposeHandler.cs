using System;

namespace UnityCommonModule.Correction.Interface {
    /// <summary>
    /// 補正値クラスのインスタンスに対して補正値の無効化を通知するクラスに約束するインターフェース
    /// </summary>
    public interface ICorrectionDisposeHandler {
        /// <summary>
        /// 補正値を無効化する際に発火されるイベント
        /// </summary>
        public Action DisposeEvent { get; set; }
    }

}