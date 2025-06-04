using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Strategy.Interface;

namespace UnityCommonModule.Correction.Strategy {
    
    public class FixedCalculateStrategy : ICalculateStrategy {
        
        protected List<ACorrection>  m_corrections = new List<ACorrection>();

        public FixedCalculateStrategy(ref List<ACorrection> corrections) {
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