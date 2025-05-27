using System;

namespace UnityCommonModule.Correction.Interface {
    /// <summary>
    /// インスタンスされた補正値クラスの無効化を通知するクラスに対して約束するインターフェース
    /// </summary>
    public interface IDisposeHandler {
        /// <summary>
        /// 補正値を無効化する際に発火されるイベント
        /// </summary>
        public Action DisposeEvnet { get; set; }
    }
}