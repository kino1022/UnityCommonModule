using System;

namespace UnityCommonModule.Correction.Interface {
    /// <summary>
    /// 補正値の再適用を要求するクラスに対して約束するインターフェース
    /// </summary>
    public interface IRequireExecuteHandler {
        /// <summary>
        /// 補正値の再適用を要求するイベント
        /// </summary>
        public Action RequireExecuteEvent { get; set; }
    }
}