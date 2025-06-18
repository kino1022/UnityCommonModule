namespace UnityCommonModule.Status.Interface {
    public interface IStatus<T> {
        
        public IValueHolder<T> Raw { get; }
        
        public T Get();

        public void Set(T value);

        public void Increase(T amount);
        
        public void Decrease(T amount);
    }
}