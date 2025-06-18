using System.Collections.Generic;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.CorrectionType {
    /// <summary>
    /// 割合での補正値を示すクラス
    /// </summary>
    public class RatioType : ICorrectionType{
        public float Calculate(float value,List<ICorrection> corrections) {
            return value + (1.0f + CalculateTotalValue(corrections));
        }

        protected float CalculateTotalValue (List<ICorrection> corrections) {
            var result = 0.0f;
            foreach (var correction in corrections) {
                result += correction.Value;
            }
            return result;
        }
    }
}