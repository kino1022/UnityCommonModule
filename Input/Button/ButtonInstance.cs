using System;
using UnityCommonModule.Input.Button.Data;
using UnityCommonModule.Input.Button.Interface;
using UnityCommonModule.Input.Button.Situation;
using UnityEngine.InputSystem;

namespace UnityCommonModule.Input.Button {
    
    public class ButtonInstance : IDisposable , IButtonInstance{

        protected InputActionMap m_input;

        protected InputAction m_action;

        protected IButtonSituation m_situation;
        
        protected ButtonData m_data;
        
        
        public ButtonData Data => m_data;
        
        public ButtonInstance(ButtonData data) {
            m_data = data;
            m_input = m_data.Input;
            m_situation = new NoneSituation(this);
            
            
        }

        public void Dispose() {
            m_input.Disable();
        }

        public void OnButton(InputAction.CallbackContext context) {
            
            if (context.performed) {
                m_situation.OnPress();
            }

            if (context.canceled) {
                m_situation.OnRelease();
            }
            
        }

        public void SetSituation(IButtonSituation situation) {
            m_situation.EndSituation();
            m_situation = situation;
            m_situation.StartSituation();
        }
        
    }
}