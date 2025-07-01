using System;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Instance.Asset {
    /// <summary>
    /// 通常の補正値
    /// </summary>
    [Serializable]
    public class NormalCorrection : ACorrection {

        public NormalCorrection(float value, ICorrectionType type): base (type, value) {}
        
        public override void OnExecuted() { }
    }
}