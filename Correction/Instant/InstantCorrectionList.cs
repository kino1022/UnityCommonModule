namespace UnityCommonModule.Correction.Instant {
    
    public class InstantCorrectionList : ACorrectionList<InstantCorrection>  {
        
        #region API Methods

        public virtual void Used() {
            OnUsed();
        }

        #endregion
        
        #region HoolPoint

        protected virtual void OnUsed() {
            foreach (var correction in m_corrections) {
                correction.Used();
            }
        }
        
        #endregion
    }
}