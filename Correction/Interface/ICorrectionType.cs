using System.Collections.Generic;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrectionType {
        public float Calculate(float value, List<ICorrection> corrections);

    }
}