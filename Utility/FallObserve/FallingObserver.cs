using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityCommonModule.FallObserve.Interface;
using UnityEngine;

namespace UnityCommonModule.Utility.FallObserve {
    /// <summary>
    /// キャラクターの落下状態を管理するMonobehaviour
    /// </summary>
    public class FallingObserver : SerializedBehaviour , IIsFallingHolder{
        [SerializeField] protected bool m_isFalling;
        [SerializeField] protected int m_delayFrame = 5;

        public void Awake() {
            CaptureIsFalling().Forget();
        }
        
        
        public bool GetIsFalling() {
            return m_isFalling;
        }
        
        protected async UniTask CaptureIsFalling() {
            var token = this.GetCancellationTokenOnDestroy();
            while (!token.IsCancellationRequested) {
                var isFalling = await ObserveTransform();
                if (isFalling) {
                    m_isFalling = true;
                }
                else {
                    m_isFalling = false;
                }
            }
        } 
        
        protected async UniTask<bool> ObserveTransform() {
            var previousTransform = this.transform.position;
            await UniTask.DelayFrame(
                m_delayFrame, 
                PlayerLoopTiming.Update,
                this.GetCancellationTokenOnDestroy()
            );
            if (previousTransform.y > this.transform.position.y) {
                return true;
            }
            return false;
        }
    }
}