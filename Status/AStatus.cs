using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Status.Interface;
using UnityCommonModule.Status.Modules;
using UnityEngine;

namespace UnityCommonModule.Status {
    [Serializable]
    public abstract class AStatus<T> : SerializedMonoBehaviour {
        
        [SerializeField, OdinSerialize, LabelText("値")] protected RawValueManageModule<T> m_rawValue;
        public IValueHolder<T> RawValue => m_rawValue;
        
    }
}