namespace UnityCommonModule.Status {

    public class FloatStatus : AStatus<float> {
        #region API Methods

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
    }
}