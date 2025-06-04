using System;
using Sirenix.Serialization;
using UnityEngine;

namespace UnityCommonModule.Script.UnityCommonModule.Status {
    [Serializable]
    public class AStatusValueBase<T> {
        
        private T _value;

        protected T m_value {
            get { return _value; }
            set {
                _value = value;
                OnValueChanged();
            }
        }

        #region API methods

        public T GetValue() {
            return m_value;
        }

        public void SetValue(T value) {
            m_value = value;
        }

        #endregion
        
        #region hook point 
        
        protected virtual void OnValueChanged() {}
        
        #endregion
    }
}