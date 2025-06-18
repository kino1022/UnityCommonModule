using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Module.Calculator {
    public class IntCalculator : ICalculator<int> {
        
        public int Add (int a, int b) {
            return a + b;
        }

        public int Subtract(int a, int b) {
            return a - b;
        }

        public int Multiply(int a, int b) {
            return a * b;
        }

        public int Divide(int a, int b) {
            return a / b;
        }

        public int ApplyCorrection(int baseValue, ICorrector correction) {
            return (int)correction.Execute(baseValue);
        }
    }
}