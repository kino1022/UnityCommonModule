using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction {
    public class FixedCorrectionList : ACorrectionList, ICorrectionExecutor {
        public override float ExecuteCorrection(float value) {
            return value + m_totalValue;
        }
    }
}