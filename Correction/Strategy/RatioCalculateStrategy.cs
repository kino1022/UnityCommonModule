using System.Collections.Generic;
using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Correction.Strategy.Interface {
    public class RatioCalculateStrategy<C> : ICalculateStrategy<C> where C : ACorrection {
        
        protected List<C> m_corrections;

        public RatioCalculateStrategy(ref List<C> corrections) {
            m_corrections = corrections;
        }

        public float ApplyCorrection(float value) {
            return value * CalculateTotalValue();
        }

        public float CalculateTotalValue() {
            var result = 100.0f;

            foreach (var correction in m_corrections) {
                result += correction.GetValue();
            }

            return result * 0.01f;
        }
    }
}