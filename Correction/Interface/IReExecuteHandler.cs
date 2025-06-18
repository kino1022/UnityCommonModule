using System;

namespace UnityCommonModule.Correction.Interface {
    /// <summary>
    /// 補正値の再適用の必要を通知するイベント
    /// </summary>
    public interface IReExecuteHandler {
        
        public Action ReExecuteEvent { get; set; }
        
        
    }
}