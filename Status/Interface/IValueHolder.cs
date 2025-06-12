namespace UnityCommonModule.Status.Interface {
    public interface IValueHolder<T> {
        
        public T GetValue();
        
        public void SetValue(T value);
        
    }
}