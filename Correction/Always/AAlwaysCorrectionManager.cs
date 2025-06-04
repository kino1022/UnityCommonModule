using System;
using UnityCommonModule.Correction.Always.Interface;

namespace UnityCommonModule.Correction.Always {
    public class AAlwaysCorrectionManager : ACorrectionManager<AAlwaysCorrection> , IRequireReExecuteHandler {
        
        public Action RequireReExecuteEvent { get; set; }

        #region Listener

        protected virtual void AddListenerList(IRequireReExecuteHandler handler) {
            handler.RequireReExecuteEvent += RequireReExecuteEvent;
        }

        protected virtual void RemoveListenerList(IRequireReExecuteHandler handler) {
            handler.RequireReExecuteEvent -= RequireReExecuteEvent;
        }
        
        #endregion
        
        
        #region Hook Point

        protected virtual void OnRequireReExecute() {
            RequireReExecuteEvent?.Invoke();
        }
        
        #endregion
    }
}