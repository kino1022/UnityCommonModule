using System;

namespace UnityCommonModule.Correction.Always.Interface {
    /// <summary>
    /// 補正値の再適用を申請するクラスに対して約束するインターフェース
    /// </summary>
    public interface IRequireReExecuteHandler {
        
        /// <summary>
        /// 再適用を申請する際に発火するイベント
        /// </summary>
        public Action RequireReExecuteEvent { get; set; }
        
    }
}