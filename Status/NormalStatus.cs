using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace UnityCommonModule.Script.UnityCommonModule.Status {
    
    public class NormalStatus : SerializedBehaviour {   
        
        [SerializeField,OdinSerialize,LabelText("ステータスの値")] 
        protected RawStatusValue<float> m_rawStatus;

        #region API Methods
        

        #endregion
    }
}