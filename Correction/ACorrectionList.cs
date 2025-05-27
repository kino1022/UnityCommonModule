using System;
using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction {
    [Serializable]
    public abstract class ACorrectionList : ICorrectionValueChangeHandler , ICorrectionExecutor {
        
        public readonly CorrectionType CorrectionType;
        
        protected List<ACorrection> m_corrections = new List<ACorrection>();

        private float _totalValue;

        protected float m_totalValue {
            get { return _totalValue; }
            set {
                
            }
        }
        
        public Action CorrectionValueChangeEvent { get; set; }
        
        //--------------------------API Methods---------------------------------
        
        public abstract float ExecuteCorrection(float value);

        public virtual float GetTotalValue() {
            return m_totalValue;
        }
        
        //--------------------------Listener methods----------------------------

        protected void AddListenerValueChange(ACorrection correction) {
            
        }

        protected void RemoveListenerValueChange(ACorrection correction) {
            
        }

        protected void AddListenerDisposeCorrection(ACorrection correction) {
            
        }

        protected void RemoveListenerDisposeCorrection(ACorrection correction) {
            
        }
        
        //--------------------------Hook Point----------------------------------

        protected virtual void OnDisposeCorrection() {
            
        }

        protected virtual void OnCorrectionValueChange() {
            
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