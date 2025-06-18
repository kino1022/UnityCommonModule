using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.CorrectionType {
    /// <summary>
    /// 固定値での補正値を示すクラス
    /// </summary>
    public class FixedType : ICorrectionType {
        
        public float Calculate(float value,List<ICorrection> corrections) {
            return value + CalculateTotalValue(corrections);
        }

        protected float CalculateTotalValue(List<ICorrection> corrections) {
            var result = 0.0f;
            foreach (var correction in corrections) {
                result += correction.Value;
            }
            return result;
        }
        
    }
}