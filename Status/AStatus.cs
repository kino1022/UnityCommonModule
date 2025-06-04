using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace UnityCommonModule.Status {
    
    public class AStatus<T> : SerializedBehaviour {   
        
        [SerializeField,OdinSerialize,LabelText("ステータスの値")] 
        protected RawStatusValue<T> m_rawStatus;

        #region API Methods
        
        public virtual T GetValue() {
            return m_rawStatus.GetValue();
        }
        
        public virtual void Set (T value) { }
        
        public virtual void Increase (T value) { }
        
        public virtual void Decrease (T value) { }

        #endregion
        
        #region Hook Point

        protected virtual void OnPreValueChange () { }

        protected virtual void OnPostValueChanged () { }

        #endregion
    }
}