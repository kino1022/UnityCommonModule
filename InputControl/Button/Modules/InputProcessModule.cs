using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Data;
using UnityCommonModule.InputControl.Button.Definition;
using UnityCommonModule.InputControl.Button.Interface;
using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Button.Modules {
    [Serializable]
    public class InputProcessModule : IDisposable {
        
        [OdinSerialize, LabelText("割り当てられた入力")]
        protected InputAction m_inputAction;
        
        protected ISituationHolder m_situation;
        
        protected IHoldHandler m_holdHandler;

        public InputProcessModule(AButtonBase button,ButtonInitializeData data) {
            m_inputAction = data.m_ActionMap;
            
            SetUpInputAction();
            
            m_situation = button.Situation;
            m_holdHandler = button.HoldHandler;
        }

        public void Dispose() {
            DisposeInputAction();
        }

        protected void SetUpInputAction() {
            
            m_inputAction.Enable();
            
            m_inputAction.performed += OnPerformed;
            m_inputAction.canceled += OnCanceled;
        }

        protected void DisposeInputAction() {
            m_inputAction.performed -= OnPerformed;
            m_inputAction.canceled -= OnCanceled;
            
            m_inputAction.Dispose();
        }

        public void OnPerformed(InputAction.CallbackContext context) {
            m_situation.SetSituation(ButtonSituation.Press);
        }

        public void OnCanceled(InputAction.CallbackContext context) {
            m_situation.SetSituation(ButtonSituation.None);
        }
        
        
    }
}