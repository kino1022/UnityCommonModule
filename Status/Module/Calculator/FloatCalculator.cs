using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Module.Calculator {
    public class FloatCalculator : ICalculator<float> {
        
        public float Add(float a, float b) {
            return a + b;
        }

        public float Subtract(float a, float b) {
            return a - b;
        }

        public float Multiply(float a, float b) {
            return a * b;
        }

        public float Divide(float a, float b) {
            return a / b;
        }

        public float ApplyCorrection(float baseValue, ICorrector correction) {
            return correction.Execute(baseValue);
        }
    }
}