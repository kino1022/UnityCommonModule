using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityCommonModule.Input.Button.Interface;

namespace UnityCommonModule.Input.Button.Situation {
    public class PressSituation : AButtonSituation {

        protected CancellationTokenSource m_cts;
        
        public PressSituation(IButtonInstance button) : base(button) { }

        public override void StartSituation() {
            CancellationToken token = m_cts.Token;
        }

        public override void EndSituation() {
            m_cts.Cancel();
        }

        public override void OnPress() {
            WaitHoldInput().Forget();
        }

        public override void OnRelease() {
            m_cts.Cancel();
        }

        protected async UniTask WaitHoldInput() {
            
            try {
                await UniTask.Delay(TimeSpan.FromSeconds(m_button.Data.HoldTime));
                m_button.SetSituation(new HoldSituation(m_button));
            }
            catch (OperationCanceledException) {
                m_button.SetSituation(new NoneSituation(m_button));
            }
            
        }
    }
}