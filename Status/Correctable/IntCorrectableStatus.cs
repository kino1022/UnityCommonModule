namespace UnityCommonModule.Status.Correctable {
    public class IntCorrectableStatus : ACorrectableStatus<int> {
        
        public override void Increase(int value) {
            OnPreValueChange();
            m_rawStatus.SetValue(GetValue() + value); 
            OnPostValueChanged();
        }

        public override void Decrease(int value) {
            OnPreValueChange();
            m_rawStatus.SetValue(GetValue() - value);
            OnPostValueChanged();
        }

        protected override void ApplyCorrection() {
            m_corrected.SetValue((int)
                m_correction.ExecuteCorrection(
                    m_rawStatus.GetValue()
                    )
                );
        }
    }
}
