using System;
using UnityCommonModule.Correction;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrectionDisposeHandler {
        public Action<ACorrection> CorrectionDisposeEvnet { get; set; }
    }
}