using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Correctable;

namespace UnityCommonModule.Status.Strategy {
    public class FloatCalculateStrategy : ICalculateStrategy<float> {

        public void Increase(float value, ref RawStatusValue<float> raw) {
            raw.SetValue(raw.GetValue() + value);
        }

        public void Decrease(float value, ref RawStatusValue<float> raw) {
            raw.SetValue(raw.GetValue() - value);
        }

        public void ApplyCorrection(ref RawStatusValue<float> raw, ref CorrectedStatusValue<float> corrected, ref ICorrectionManager correction) {
            corrected.SetValue(
                correction.ExecuteCorrection(
                    raw.GetValue()
                    )
                );
        }
    }
}