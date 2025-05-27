using System;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrectionValueChangeHandler {
        public Action CorrectionValueChangeEvent { get; set; }
    }
}