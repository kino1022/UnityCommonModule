using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityCommonModule.FallObserve.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace UnityCommonModule.Utility.FallObserve {
    public class FallHeightManager : SerializedBehaviour , IFallHeightHolder {
        
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
                    //落下するまでの待機
                    await UniTask.WaitUntil(
                        () => m_isFallingHolder.GetIsFalling(), 
                        PlayerLoopTiming.Update, 
                        token
                        );
                    var previousHeight = this.transform.position.y;
                    //落下終了までのループ処理
                    while (m_isFallingHolder.GetIsFalling()) {
                        await UniTask.DelayFrame(
                            1,
                            PlayerLoopTiming.Update,
                            token
                            );
                        m_Height += previousHeight - this.transform.position.y;
                        previousHeight = this.transform.position.y;
                    }
                    //着地後の処理
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