namespace UnityCommonModule.Status.Correctable {

    public class FloatCorrectableStatus : ACorrectableStatus<float> {

        #region API

        public override void Increase(float value) {
            OnPreValueChange();
            m_rawStatus.SetValue(GetValue() + value);
            OnPostValueChanged();
        }


        public override void Decrease(float value) {
            OnPreValueChange();
            m_rawStatus.SetValue(GetValue() - value);
            OnPostValueChanged();
        }

        #endregion

        #region Logic

        protected override void ApplyCorrection() { m_corrected.SetValue(m_correction.ExecuteCorrection(m_rawStatus.GetValue())); }

        #endregion

    }
}