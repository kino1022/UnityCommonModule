using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Strategy.Interface;

namespace UnityCommonModule.Correction.Strategy {
    
    public class FixedCalculateStrategy<C> : ICalculateStrategy<C> where C : ACorrection {
        
        protected List<C>  m_corrections = new List<C>();

        public FixedCalculateStrategy(ref List<C> corrections) {
            this.m_corrections = corrections;
        }

        public float ApplyCorrection(float value) {
            return value + CalculateTotalValue();
        }

        public float CalculateTotalValue() {
            var result = 0.0f;
            foreach (var correction in m_corrections) {
                result += correction.GetValue();
            }
            return result;
        }
    }
}