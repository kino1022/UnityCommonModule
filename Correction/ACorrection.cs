using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction {
    [Serializable]
    public class ACorrection {

        [OdinSerialize] protected CorrectionType m_type;
        
        [OdinSerialize] private float _value;

        protected float m_value {
            get {return _value;}
            set {
                value = OnPreValueChange(value);
                _value = value;
                OnPostValueChange();
            }
        }

        public Action<ACorrection> DisposeEvent;
        
        protected List<ICorrectionDisposeHandler> m_handlers = new List<ICorrectionDisposeHandler>();

        public ACorrection(float value,CorrectionType type) {
            m_value = value;
            m_type = type;
        }

        public ACorrection(float value,CorrectionType type, List<ICorrectionDisposeHandler> handlers) {
            m_value = value;
            m_type = type;
            m_handlers = handlers;
            AddListenerHandler();
        }

        #region API Methods

        public float GetValue() {
            return m_value;
        }

        public CorrectionType GetCorrectionType() {
            return m_type;
        }

        #endregion
        

        #region Listener

        protected void AddListenerHandler() {
            if (m_handlers == null) {
                return;
            }

            foreach (var handler in m_handlers) {
                handler.DisposeEvent += OnDisposeEvent;
            }
        }

        protected void RemoveListenerHandler() {
            if (m_handlers == null) {
                return;
            }

            foreach (var handler in m_handlers) {
                handler.DisposeEvent -= OnDisposeEvent;
            }
        }

        #endregion
        
        
        #region Hook Point

        protected virtual float OnPreValueChange(float value) {
            return value;
        }
        
        protected virtual void OnPostValueChange () { }

        protected virtual void OnDisposeEvent() {
            RemoveListenerHandler();
            DisposeEvent?.Invoke(this);
        }
        
        #endregion
    }
}