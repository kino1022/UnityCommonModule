using System;
using System.Threading;

namespace Modules.Utility.Counter {
    /// <summary>
    /// 一定時間毎に指定されたActionを発火するクラス
    /// </summary>
    public class SecondsInvoker : SecondsCounter {
        /// <summary>
        /// 実行する間隔
        /// </summary>
        protected float m_interval;
        /// <summary>
        /// 実行する関数
        /// </summary>
        protected Action m_callback;

        public SecondsInvoker(float interval, Action callback, CancellationToken token) : base(token) {
            m_interval = interval;
            m_callback = callback;
        }

        protected override void OnPostCountChange() {
            base.OnPostCountChange();
            if (m_count % m_interval == 0) {
                m_callback?.Invoke();
            }
        }
    }
}