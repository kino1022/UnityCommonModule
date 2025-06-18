namespace UnityCommonModule.Status.Interface {
    public interface IValueHolder<T> {
        
        public T Get();
        
        public void Set(T value);
        
    }
}