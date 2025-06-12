using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Status.Modules {
    public class CorrectValueManageModule<T> : AValueManageModule<T> {
        public CorrectValueManageModule(T initialValue) : base(initialValue){}
    }
}