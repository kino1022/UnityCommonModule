using System;
using Sirenix.OdinInspector;
using UnityCommonModule.Input.Leber.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.Input.Leber {
    [Serializable]
    public class Lever : ILever {
        
        [SerializeField, LabelText("入力方向")]
        protected Vector2 m_pos = Vector2.down;
        
        public Vector2 Pos => m_pos;

        public void OnInput(InputAction.CallbackContext context) {
            
            if (context.performed) {
                Debug.Log($"{this.GetType()}への入力がありました");
                m_pos = context.ReadValue<Vector2>().normalized;
            }

            if (context.canceled) {
                Debug.Log($"{this.GetType()}への入力が終了しました");
                m_pos = Vector2.zero;
            }
        }
        
        
    }
}