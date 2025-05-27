using System;

namespace UnityCommonModule.Status {
    [Serializable]
    public class AStatusElement {
        
        private float _value;

        protected float m_value {
            get {
                if (m_allowMinus && _value < 0.0f) return 0.0f;
                return m_value;
            }
            set {
                value = OnPreValueChange(value);
                m_value = value;
                OnPostValueChange();
            }
        }
        
        protected bool m_allowMinus = false;

        public AStatusElement(float value,bool allowMinus) {
            m_value = value;
            m_allowMinus = allowMinus;
        }
        
        //--------------------------API Methods----------------------------------

        public float GetValue() {
            return m_value;
        }

        public void AddValue(float value) {
            m_value += value;
        }

        public void SetValue(float value) {
            m_value = value;
        }
        
        //--------------------------Hook Point Methods---------------------------

        protected virtual float OnPreValueChange(float value) {
            return value;
        }
        
        protected virtual void OnPostValueChange () {}
    }
}