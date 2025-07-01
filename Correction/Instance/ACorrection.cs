using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Instance {
    /// <summary>
    /// 補正値の基底クラス
    /// </summary>
    [Serializable]
    public abstract class ACorrection : ICorrection {
        
        [OdinSerialize, LabelText("補正値の分類")]
        protected ICorrectionType m_type;
        
        [OdinSerialize, LabelText("補正量")]
        protected float m_value;

        protected bool m_isActive = true;
        
        public ICorrectionType Type => m_type;
        
        public float Value => m_value;
        
        public bool IsActive => m_isActive;
        

        public virtual void Dispose() {
            m_value = 0.0f;
            m_isActive = false;
        }
        
        public abstract void OnExecuted();
    }
}