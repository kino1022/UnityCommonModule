using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityCommonModule.FallObserve.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace UnityCommonModule.Utility.FallObserve {
    public class FallHeightManager : SerializedBehaviour {
        
        [SerializeField] protected float m_Height;
        
        [SerializeField] protected IIsFallingHolder m_isFallingHolder;

        [SerializeField] public UnityEvent<float> OnGroundedUEvent;

        private void Awake() {
            FallHeightRecoder().Forget();
        }
        
        //---------------------open methods-------------------------------
        public float GetFallHeight() {
            return m_Height;
        }
        
        //---------------------task logic-----------------------------
        
        protected async UniTask FallHeightRecoder() {
            var token = this.GetCancellationTokenOnDestroy();
            while (!token.IsCancellationRequested) {
                try {
                    await UniTask.WaitUntil(
                        () => m_isFallingHolder.GetIsFalling(), 
                        PlayerLoopTiming.Update, 
                        token
                        );
                    var previousHeight = this.transform.position.y;
                    while (m_isFallingHolder.GetIsFalling()) {
                        await UniTask.DelayFrame(
                            1,
                            PlayerLoopTiming.Update,
                            token
                            );
                        m_Height += previousHeight - this.transform.position.y;
                        previousHeight = this.transform.position.y;
                    }
                    OnGroundedUEvent.Invoke(m_Height);
                    m_Height = 0.0f;
                }
                catch (OperationCanceledException) {
                    break;
                }
            }
        }
    }
}