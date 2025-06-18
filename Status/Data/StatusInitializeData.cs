using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityCommonModule.Status.Data {
    public abstract class StatusInitializeData<T> : SerializedScriptableObject {
        public T InitialValue;
    }
}