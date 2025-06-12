using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Modules {
    [Serializable]
    public class AValueManageModule<T> : IValueHolder<T> {
        
        [OdinSerialize, LabelText("管理している値")] private T _value;

        protected T m_value {
            get => _value;
            set {
                OnPreValueChange(value);
                _value = value;
                OnPostValueChange();
            }
        }

        public AValueManageModule(T initialValue) {
            _value = initialValue;
        }

        public T GetValue() {
            return m_value;
        }

        public void SetValue(T value) {
            m_value = value;
        }


        protected virtual T OnPreValueChange(T value) {
            return value;
        }
        
        protected virtual void OnPostValueChange() {}
    }
}