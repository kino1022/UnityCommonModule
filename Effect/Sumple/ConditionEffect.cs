using UnityCommonModule.Correction;

namespace UnityCommonModule.Effect.Sumple {
    /// <summary>
    /// 補正値生成効果のサンプル
    /// </summary>
    public class CorrectionEffect : AEffect<CorrectionManager> {

        public ACorrection addValue;
        
        //--------API Methods-------------------

        public override void OnActivate() {
            m_target.AddCorrection(addValue);
        }

        public override void OnDeactivate() {
            addValue.CorrectionDisposeEvnet?.Invoke(addValue);
        }
    }
}