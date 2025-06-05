using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Instant {
    /// <summary>
    /// 使用回数や効果時間に制限のある補正値に対して使用する補正値クラス
    /// </summary>
    public class InstantCorrection : ACorrection {

        public InstantCorrection(float value, CorrectionType type) : base(value, type) {
            
        }

        public InstantCorrection(float value, CorrectionType type, List<ICorrectionDisposeHandler> handlers): base(value, type, handlers) {
            
        }
        
        #region API Methods

        public void Used() {
            OnUsed();
        }
        
        #endregion
        
        #region HookPoint
        
        protected virtual void OnUsed () {}
        
        #endregion
    }
}