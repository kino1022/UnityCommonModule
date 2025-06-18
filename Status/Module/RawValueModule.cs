using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Module {

    public class RawValueModule<T> : AValueModule<T> {
        public RawValueModule(T value) : base(value) {
            
        }
    }
}