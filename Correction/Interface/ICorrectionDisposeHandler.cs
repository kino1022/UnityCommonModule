using System;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrectionDisposeHandler {
        public Action<ICorrection> DisposeEvent { get; set; }
    }
}