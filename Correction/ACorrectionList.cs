using System;
using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction {
    [Serializable]
    public abstract class ACorrectionList : ICorrectionExecutor , IRequireExecuteHandler {
        
        public readonly CorrectionType CorrectionType;
        
        protected List<ACorrection> m_corrections = new List<ACorrection>();

        private float _totalValue;

        protected float m_totalValue {
            get { return _totalValue; }
            set {
                OnPreCorrectionValueChange();
                _totalValue = value;
                OnPostCorrectionValueChange();
            }
        }
        
        public Action RequireExecuteEvent { get; set; }
        
        //--------------------------API Methods---------------------------------
        
        public abstract float ExecuteCorrection(float value);

        public virtual float GetTotalValue() {
            return m_totalValue;
        }

        public void AddCorrection(ACorrection correction) {
            if (correction.Type != this.CorrectionType) {
                Debug.Log("補正値分類が異なるクラスがリストに追加されそうになったじゃないか！お前のコードミスだ！");
                return;
            }
            m_corrections.Add(correction);
            OnCorrectionValueChange();
        }

        public void RemoveAll() {
            m_corrections.Clear();
        }

        public void RemoveAt(ACorrection correction) {
            m_corrections.Remove(correction);
        }
        
        //--------------------------Listener methods----------------------------

        protected void AddListenerValueChange(ACorrection correction) {
            correction.CorrectionValueChangeEvent += OnCorrectionValueChange;
        }

        protected void RemoveListenerValueChange(ACorrection correction) {
            correction.CorrectionValueChangeEvent -= OnCorrectionValueChange;
        }

        protected void AddListenerDisposeCorrection(ACorrection correction) {
            correction.CorrectionDisposeEvnet += OnDisposeCorrection;
        }

        protected void RemoveListenerDisposeCorrection(ACorrection correction) {
            correction.CorrectionDisposeEvnet -= OnDisposeCorrection;
        }
        
        //--------------------------Hook Point----------------------------------

        protected virtual void OnDisposeCorrection(ACorrection correction) {
            m_corrections.Remove(correction);
            OnCorrectionValueChange();
        }

        protected virtual void OnCorrectionValueChange() {
            m_totalValue = GetTotalValue();
        }

        protected virtual void OnPreCorrectionValueChange() { }

        protected virtual void OnPostCorrectionValueChange() {
            RequireExecuteEvent?.Invoke();
        }
        
        //--------------------------Logical Methods-----------------------------

        protected virtual float CalculateTotalValue() {
            var result = 0.0f;
            foreach (var correction in m_corrections) {
                result += correction.GetCorrectionValue();
            }
            return result;
        }
    }
}