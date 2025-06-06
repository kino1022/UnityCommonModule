using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Script.UnityCommonModule.InputControl.Button.Interface;
using UnityEngine;

namespace UnityCommonModule.InputControl.Button.Modules {
    public class HookExecuteModule : IHookExecutor {
        
        [SerializeField, OdinSerialize, LabelText("離された際の処理フック")]
        protected List<AOnReleaseHook> m_releaseHook;

        [SerializeField, OdinSerialize, LabelText("押された際の処理フック")]
        protected List<AOnPressHook> m_pressHook;

        [SerializeField, OdinSerialize, LabelText("長押しされた際の処理フック")]
        protected List<AOnHoldHook> m_holdHook;

        public HookExecuteModule(List<AOnReleaseHook> release, List<AOnPressHook> press, List<AOnHoldHook> hold) {
            m_releaseHook = release;
            m_pressHook = press;
            m_holdHook = hold;
        }
    }
}