namespace UnityCommonModule.Status {

    public class IntStatus : AStatus<int> {

        #region API

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

        #endregion

    }
}