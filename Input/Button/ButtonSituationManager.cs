using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityCommonModule.Input.Button.Definition;
using UnityCommonModule.Input.Button.Interface;
using UnityEngine;
using UnityEngine.Events;
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

        [SerializeField] protected float m_requireSeconds;
        
        [SerializeReference] protected HoldInputObserver m_observer;

        [SerializeField] protected HoldDurationCounter m_counter;
        
        public Action<ButtonSituation> SituationChangeEvent { get; set; }
        
        public UnityEvent<float> ReleaseHoldUEvent { get; set; }
        
        //-------------------API methods----------------------------

        public ButtonSituation GetSituation() {
            return m_situation;
        }

        public void OnButton(InputAction.CallbackContext context) {
            if (context.performed) {
                OnPerformed();
            }

            if (context.canceled) {
                OnCanceled();
            }
        }
        
        //-------------------Observer methods--------------------------

        protected void SetUpObserver() {
            m_observer = new HoldInputObserver(this, m_requireSeconds, this.destroyCancellationToken);
            m_observer.HoldCompleteEvent += OnHoldCompleted;
        }

        protected void DisposeObserver() {
            m_observer.HoldCompleteEvent -= OnHoldCompleted;
        }
        
        //-------------------Counter methods-----------------------

        protected void SetUpCounter() {
            m_counter = new HoldDurationCounter(this, this.destroyCancellationToken);
            m_counter.ReleaseEvent += OnReleaseEvent;
        }

        protected void DisposeCounter() {
            m_counter.ReleaseEvent -= OnReleaseEvent;
        }
        
        //-------------------Hook Point------------------------------

        protected virtual void OnSituationChanged() {
            switch (m_situation) {
                case ButtonSituation.None: OnNone(); break;
                case ButtonSituation.Press : OnPress(); break;
                case ButtonSituation.Hold : OnHold(); break;
            }
        }

        protected virtual void OnPerformed() {
            if (m_situation == ButtonSituation.None) {
                m_situation = ButtonSituation.Press;
            }
        }

        protected virtual void OnCanceled() {
            if (m_situation == ButtonSituation.Hold) {
                OnRelease();
            }
            m_situation = ButtonSituation.None;
        }
        
        protected virtual void OnNone () {}

        protected virtual void OnPress() { }
        
        protected virtual void OnHold() {}
        
        protected virtual void OnRelease() {}

        protected virtual void OnHoldCompleted() {
            m_situation = ButtonSituation.Hold;
            DisposeObserver();
            SetUpObserver();
        }


        protected void OnReleaseEvent(float duration) {
            ReleaseHoldUEvent?.Invoke(duration);
            DisposeObserver();
            SetUpObserver();
        }
        
        //---------------------logic methods----------------------------
        
    }
}