using System;
using Sirenix.OdinInspector;
using UnityCommonModule.Input.Button.Definition;
using UnityCommonModule.Input.Button.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.Input.Button {
    /// <summary>
    /// InputSystemと連携してボタンの置かれている状態を管理するコンポーネント
    /// </summary>
    public class ButtonSituationManager : SerializedMonoBehaviour, IChangeSituationHandler , ISituationHolder {
        
        [SerializeField] private ButtonSituation _situation;

        protected ButtonSituation m_situation {
            get { return _situation; }
            set {
                if (_situation == value) return;
                _situation = value;
                OnSituationChanged();
                SituationChangeEvent?.Invoke(_situation);
            }
        }
        
        public Action<ButtonSituation> SituationChangeEvent { get; set; }
        
        
        //-------------------API methods----------------------------

        public ButtonSituation GetSituation() {
            return m_situation;
        }

        public void OnButton(InputAction.CallbackContext context) {
            if (context.performed) {
                
            }

            if (context.canceled) {
                
            }
        }
        
        //-------------------Hook Point------------------------------

        protected virtual void OnSituationChanged() {
            
        }
    }
}