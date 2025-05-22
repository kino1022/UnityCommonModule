using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace UnityCommonModule.Utility.FallObserve {
    public class FallingObserver : SerializedBehaviour {
        protected bool m_isFalling;

        private void Awake() {
            
        }
        
        protected async UniTask ObserveFalling() {
            var token = this.GetCancellationTokenOnDestroy();
            while (token)
        }
    }
}