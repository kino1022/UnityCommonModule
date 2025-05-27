using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction {
    public class RatioCorrectionList  : ACorrectionList, ICorrectionExecutor {
        public override float ExecuteCorrection(float value) {
            return value +  (value * m_totalValue);
        }
    }
}