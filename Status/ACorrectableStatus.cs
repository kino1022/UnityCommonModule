using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Always;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Interface;
using UnityCommonModule.Status.Modules;
using UnityEngine;

namespace UnityCommonModule.Status {
    public abstract class ACorrectableStatus<T> : AStatus<T> {
        [SerializeField, OdinSerialize, LabelText("補正後の値")]
        protected CorrectValueManageModule<T> m_corrected;

        [SerializeField, OdinSerialize, LabelText("補正管理クラス")]
        protected AlwaysCorrectionManager m_correction;

        protected ValueSyncModule m_syncModule;
        
        public IValueHolder<T> Corrected => m_corrected;
        
        public ICorrectionManager Correction => m_correction;
    }
}