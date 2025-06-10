using System;
using System.Collections.Generic;
using UnityCommonModule.Correction.Always.Interface;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Always {
    /// <summary>
    /// 常に最新の値を取得する必要のある補正値に使用する補正値クラス
    /// </summary>
    [Serializable]
    public class AlwaysCorrection : ACorrection , IRequireReExecuteHandler  {
        
        public Action RequireReExecuteEvent { get; set; }
        
        public AlwaysCorrection(float value, CorrectionType type) 
            : base(value, type) {
            
        }

        public AlwaysCorrection(float value, CorrectionType type, List<ICorrectionDisposeHandler> handlers)
            : base(value, type, handlers) {
            
        }

        #region HookPoint

        protected override void OnPostValueChange() {
            base.OnPostValueChange();
            RequireReExecuteEvent?.Invoke();
        }

        #endregion
    }
}