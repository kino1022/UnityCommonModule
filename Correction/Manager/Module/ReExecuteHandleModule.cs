using System;
using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Module {
    
    public class ReExecuteHandleModule : IReExecuteHandler , IDisposable {
        
        protected List<IReExecuteHandler> m_handlers = new List<IReExecuteHandler>();

        public Action ReExecuteEvent { get; set; }
        
        public void Dispose() {
            foreach (var handler in m_handlers) {
                RemoveListenerHandler(handler);
            }
        }

        public void AddModule(IReExecuteHandler handler) {
            m_handlers.Add(handler);
            AddListenerHandler(handler);
        }

        public void RemoveModule(IReExecuteHandler handler) {
            m_handlers.Remove(handler);
            RemoveListenerHandler(handler);
        }

        protected void AddListenerHandler(IReExecuteHandler handler) {
            handler.ReExecuteEvent += OnHandle;
        }

        protected void RemoveListenerHandler(IReExecuteHandler handler) {
            handler.ReExecuteEvent -= OnHandle;
        }

        protected virtual void OnHandle() {
            ReExecuteEvent?.Invoke();
        }
    }
    
}