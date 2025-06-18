using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Status.Interface {
    public interface ICorrectableStatus<T> : IStatus<T> {
        
        public IValueHolder<T> Corrected { get; }
        
        public ICorrector Correction { get; }
        
    }
}