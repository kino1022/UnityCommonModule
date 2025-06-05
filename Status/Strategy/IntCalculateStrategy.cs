using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Correctable;

namespace UnityCommonModule.Status.Strategy {
    public class IntCalculateStrategy : ICalculateStrategy<int> {

        public void Increase(int amount, ref RawStatusValue<int> raw) {
            
        }

        public void Decrease(int amount, ref RawStatusValue<int> raw) {
            
        }

        public void ApplyCorrection(ref RawStatusValue<int> raw, ref CorrectedStatusValue<int> corrected, ref ICorrectionManager correction) {
            
        }
        
    }
}