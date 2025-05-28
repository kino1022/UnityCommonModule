using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Modules.Utility.Counter {
    /// <summary>
    /// 指定した秒数になるとイベントを発火するSecondsCounter
    /// </summary>
    public class SecondsNotificator : SecondsCounter {
        
        protected float m_notice;

        public Action NotificationEvent;
        
        public SecondsNotificator(float noticeTime, CancellationToken token) : base(token) {
            m_notice = noticeTime;
        }

        protected override void OnPostCountChange() {
            base.OnPostCountChange();
            if (m_count == m_notice) {
                NotificationEvent?.Invoke();
            }
        } 
    }
}