using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status.Data;
using UnityCommonModule.Status.Interface;
using UnityCommonModule.Status.Module;
using UnityEngine;

namespace UnityCommonModule.Status {

    public abstract class AStatus<T,C> : SerializedMonoBehaviour , IStatus<T> where C : ICalculator<T> , new() {

        [SerializeField, OdinSerialize, LabelText("初期化用データ")]
        protected StatusInitializeData<T> m_data;

        protected RawValueModule<T> m_rawValue;

        protected C m_calculator = new C();

        public IValueHolder<T> Raw => m_rawValue;

        private void Awake() {
            if (m_data == null) {
                Debug.LogError("ステータス初期化用のデータが存在しませんでした");
                return;
            }

            Initialize();
        }

        [OdinSerialize, LabelText("現在の値")]
        public virtual T Get => m_rawValue.Get();

        public virtual void Set(T value) {
            m_rawValue.Set(value);
            OnPostValueChange();
        }

        public void Increase(T amount) {
            amount = OnPreValueChange(amount);
            m_rawValue.Set(m_calculator.Add(m_rawValue.Get(), amount));
            OnPostValueChange();
        }

        public void Decrease(T amount) {
            amount = OnPreValueChange(amount);
            m_rawValue.Set(m_calculator.Subtract(m_rawValue.Get(), amount));
            OnPostValueChange();
        }

        protected void Initialize() {
            OnInitialize();
        }

        protected virtual void OnInitialize() {
            m_rawValue = new RawValueModule<T>(m_data.InitialValue);
        }

        protected virtual T OnPreValueChange(T nextValue) {
            return nextValue;
        }

        protected virtual void OnPostValueChange () {}

    }
}
