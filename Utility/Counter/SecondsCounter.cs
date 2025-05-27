using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Utility.Counter {
    /// <summary>
    /// 秒数をカウントするカウンタ
    /// </summary>
    public class SecondsCounter : ACounter<float> {
        
        CancellationToken token = CancellationToken.None;

        private float m_countInterval;

        public SecondsCounter(CancellationToken token, float countInterval = 0.1f) {
            this.token = token;
            m_countInterval = countInterval;
        }
        
        protected async UniTask counter() {
            while (!token.IsCancellationRequested) {
                try {
                    await UniTask.Delay(TimeSpan.FromSeconds(m_countInterval), cancellationToken: token);
                    m_countInterval += m_countInterval;
                }
                catch (OperationCanceledException) {
                    break;
                }
            }
        } 
    }
}