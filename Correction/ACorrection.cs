using System;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction {
    [Serializable]
    public class ACorrection {
        
        public readonly CorrectionType Type;
        
        private float _value;
        
        protected float m_value {
            get { return _value; }
            set {
                value = OnPreValueChanged(value);
                _value = value;
                OnPostValueChanged();
            }
        }

        protected IDisposeHandler m_dispose;
        
        public Action<ACorrection> CorrectionDisposeEvnet { get; set; }

        public Action CorrectionValueChangeEvent { get; set; }

        public ACorrection(CorrectionType type, float value, IDisposeHandler disposeHandler) {
            
        }
        
        //---------------------------API Methods------------------------

        public void ChangeCorrectionValue(float value) {
            m_value = value;
        }

        public float GetCorrectionValue() {
            return m_value;
        }

        public void DisposeHandle(IDisposeHandler disposeHandler) {
            disposeHandler.DisposeEvnet += OnDisposeCorrection;
        }
        
        //------------------------------購読処理--------------------------
        
        public void AddListenerDisposeHandler(IDisposeHandler handler) {
            handler.DisposeEvnet += OnDisposeCorrection;
        }

        public void RemoveListenerDisposeHandler(IDisposeHandler handler) {
            handler.DisposeEvnet -= OnDisposeCorrection;
        }
        
        //-------------------------------hook point methods---------------

        protected virtual float OnPreValueChanged(float value) {
            return value;
        }

        protected virtual void OnPostValueChanged() { }
        
        /// <summary>
        /// 補正値が無効化される際に呼び出される処理
        /// </summary>
        public void OnDisposeCorrection() {
            m_value = 0.0f;
            CorrectionDisposeEvnet?.Invoke(this);
        }
    }
}