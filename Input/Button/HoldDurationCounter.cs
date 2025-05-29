using System;
using System.Threading;
using Modules.Utility.Counter;
using UnityCommonModule.Input.Button.Definition;
using UnityCommonModule.Input.Button.Interface;

namespace UnityCommonModule.Input.Button {
    /// <summary>
    /// 長押しの長さをカウントするクラス
    /// </summary>
    public class HoldDurationCounter :  SecondsCounter {
        
        protected IChangeSituationHandler m_handler;
        
        public Action<float> ReleaseEvent { get; set; }

        public HoldDurationCounter(IChangeSituationHandler handler, CancellationToken token) : base(token) {
            m_handler = handler;
            AddListenerHandler();
        }

        protected void AddListenerHandler() {
            m_handler.SituationChangeEvent += OnChangeSituation;
        }

        protected void RemoveListenerHandler() {
            m_handler.SituationChangeEvent -= OnChangeSituation;
        }

        protected void OnChangeSituation(ButtonSituation situation) {
            if (situation == ButtonSituation.Hold) {
                StartProgress();
            }
            else {
                StopProgress();
                ReleaseEvent?.Invoke(m_count);
                m_count = 0.0f;
            }
        }
    }
}