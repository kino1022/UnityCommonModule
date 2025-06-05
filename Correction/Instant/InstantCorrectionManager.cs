namespace UnityCommonModule.Correction.Instant {
    /// <summary>
    /// 
    /// </summary>
    public class InstantCorrectionManager : ACorrectionManager<InstantCorrection> {
        
        #region Hook Point

        protected override void OnPreExecuteCorrection() {
            foreach (var list in m_list) {
                if (list is InstantCorrectionList inst) {
                    inst.Used();
                }
            }
        }
        
        #endregion
    }
}