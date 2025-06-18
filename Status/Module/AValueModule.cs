using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Module {
    
    public abstract class AValueModule<T> : IValueHolder<T> {
        
        private T _value;

        protected T m_value {
            get => _value;
            set {
                _value = value;
            }
        }

        protected AValueModule(T value) {
            _value = value;
        }

        public T Get() {
            return _value;
        }

        public void Set(T value) {
            _value = value;
        }
    }
    
}