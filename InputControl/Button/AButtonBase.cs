using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Interface;
using UnityCommonModule.InputControl.Button.Modules;
using UnityCommonModule.InputControl.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Button {
    [Serializable]
    public class AButtonBase : IInputReceiver {

        [SerializeField, OdinSerialize, LabelText("離された際の処理フック")]
        protected List<AOnReleaseHook> m_releaseHook;

        [SerializeField, OdinSerialize, LabelText("押された際の処理フック")]
        protected List<AOnPressHook> m_pressHook;

        [SerializeField, OdinSerialize, LabelText("長押しされた際の処理フック")]
        protected List<AOnHoldHook> m_holdHook;

        [SerializeField, OdinSerialize, LabelText("ボタン状態")]
        protected ISituationHolder m_situation;
        
        public ISituationHolder Situation => m_situation;


    public void OnInput(InputAction.CallbackContext context) {
            
            if (context.performed) {
                
            }

            if (context.canceled) {
                
            }
            
        }
    }
}