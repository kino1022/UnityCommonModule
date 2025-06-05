using System;
using UnityCommonModule.Correction.Always.Interface;

namespace UnityCommonModule.Correction.Always {
    [Serializable]
    public class AlwaysCorrectionManager : ACorrectionManager<AlwaysCorrection>, IAlwaysCorrectionManager , IRequireReExecuteHandler {
        
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