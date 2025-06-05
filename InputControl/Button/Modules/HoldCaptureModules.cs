using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Interface;

namespace UnityCommonModule.InputControl.Button.Modules {
    [Serializable]
    public class HoldCaptureModules : IHoldHandler {

        [OdinSerialize, LabelText("長押しに要求する時間")] protected float m_require;
        
        public Action ChangeHoldEvent { get; set; }
    }
}