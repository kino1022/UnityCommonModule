using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Utility.Counter {
    /// <summary>
    /// 秒数をカウントするカウンタ
    /// </summary>
    [Serializable]
    public class SecondsCounter : ACounter<float> {
        
        CancellationToken token = CancellationToken.None;

        private float m_countInterval;

        public SecondsCounter(CancellationToken token, float countInterval = 0.1f) {
            this.token = token;
            m_countInterval = countInterval;
        }
        
        protected override async UniTask CountTask() {
            
            while (!token.IsCancellationRequested) {
                try {
                    
                    if (m_isProgress == false) {
                        //　スパゲティ回避のために分けて書いた！知らなかったわけじゃあないやい！
                        if (await WaitForReStart(token) == false) break;
                    }
                    
                    token.ThrowIfCancellationRequested();
                    
                    await UniTask.Delay(TimeSpan.FromSeconds(m_countInterval),
                        cancellationToken: token);
                    m_countInterval += m_countInterval;
                    
                }
                catch (OperationCanceledException) {
                    break;
                }
            }
        } 
    }
}