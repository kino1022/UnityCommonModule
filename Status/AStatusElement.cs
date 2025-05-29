using System;

namespace Script.UnityCommonModule.Status {
    [Serializable]
    public class AStatusElement {
        
        private float _value;

        protected float m_value {
            get => _value;
            set {
                OnPreValueChange(value);
                _value = value;
                OnPostValueChange();
            }
        }
        
        //-------------------------API Methods------------------

        public float GetCurrent() {
            return m_value;
        }

        public void Set(float value) {
            m_value = value;
        }

        public void Add(float value) {
            m_value += value;
        }
        
        //---------------------------hook point-------------------
        
        public void OnPreValueChange (float value) {}
        
        public void OnPostValueChange () {}
    }
}