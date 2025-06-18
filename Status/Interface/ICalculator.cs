using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Status.Interface {
    public interface ICalculator<T> {
        
        public T Add (T a, T b);
        
        public T Subtract (T a, T b);
        
        public T Multiply (T a, T b);
        
        public T Divide (T a, T b);

        public T ApplyCorrection(T baseValue, ICorrector correction);
    }
}