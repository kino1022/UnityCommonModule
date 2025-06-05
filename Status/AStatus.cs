using System.Numerics;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status.Strategy;
using UnityEngine;


namespace UnityCommonModule.Status {

    public abstract class AStatus<T> : SerializedMonoBehaviour {
        
        [SerializeField,LabelText("初期値")]
        protected T m_entryValue;

        [SerializeField, OdinSerialize, LabelText("ステータスの値")]
        protected RawStatusValue<T> m_rawStatus;

        private void Awake() {
            m_rawStatus = new RawStatusValue<T>(m_entryValue);
        }

        #region API Methods

        public virtual T GetValue() { return m_rawStatus.GetValue(); }

        public virtual void Set(T value) {
            OnPreValueChange();
            m_rawStatus.SetValue(value);
            OnPostValueChanged();
        }

        public abstract void Increase(T value);

        public abstract void Decrease(T value);

        #endregion

        #region Hook Point

        protected virtual void OnPreValueChange() { }

        protected virtual void OnPostValueChanged() { }

        #endregion
    }
}
