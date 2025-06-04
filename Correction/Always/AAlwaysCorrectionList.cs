using System;
using UnityCommonModule.Correction.Always.Interface;
using UnityCommonModule.Correction.Definition;

namespace UnityCommonModule.Correction.Always {
    [Serializable]
    public class AAlwaysCorrectionList : ACorrectionList<AAlwaysCorrection> , IRequireReExecuteHandler {
        
        public Action RequireReExecuteEvent { get; set; }

        #region API

        public override float ExecuteCorrection(float value) {
            return value;
        }

        public override void AddCorrection(AAlwaysCorrection correction) {
            base.AddCorrection(correction);
            RequireReExecuteEvent?.Invoke();
        }

        public override void RemoveCorrection(AAlwaysCorrection correction) {
            base.RemoveCorrection(correction);
            RequireReExecuteEvent?.Invoke();
        }

        #endregion

        #region Listener

        protected override void AddListenerCorrection(AAlwaysCorrection correction) {
            base.AddListenerCorrection(correction);
            correction.RequireReExecuteEvent += RequireReExecuteEvent;
        }

        protected override void RemoveListenerCorrection(AAlwaysCorrection correction) {
            base.RemoveListenerCorrection(correction);
            correction.RequireReExecuteEvent -= RequireReExecuteEvent;
        }

        #endregion
        

        #region HookPoint

        public virtual void OnRequireReExecute() {
            RequireReExecuteEvent?.Invoke();
        }

        #endregion
        
        #region Logical

        protected override float CalculateTotalValue() {
            return CalculateTotalValue();
        }
        
        #endregion
        
    }
}