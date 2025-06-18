using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Instance {
    /// <summary>
    /// 補正値の基底クラス
    /// </summary>
    public abstract class ACorrection : ICorrection {
        
        protected ICorrectionType m_type;

        protected float m_value;

        protected bool m_isActive = true;
        
        public ICorrectionType Type => m_type;
        
        public float Value => m_value;
        
        public bool IsActive => m_isActive;

        protected ACorrection(ICorrectionType type, float value) {
            m_type = type;
            m_value = value;
        }

        public virtual void Dispose() {
            m_value = 0.0f;
            m_isActive = false;
        }
        
        public abstract void OnExecuted();
    }
}