namespace UnityCommonModule.Status {
    
    public class RawStatusValue<T> : AStatusValueBase<T> {

        public RawStatusValue(T value) {
            this.m_value = value;
        }

    }
}