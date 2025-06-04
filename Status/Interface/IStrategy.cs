namespace UnityCommonModule.Status.Interface {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStrategy<T> {
        public T Apply(T value);
    }
}