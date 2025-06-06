using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Definition;
using UnityCommonModule.InputControl.Button.Interface;
using UnityEngine;

namespace UnityCommonModule.InputControl.Button.Modules {
    [Serializable]
    public class HoldCaptureModules : AOnPressHook , IHoldHandler {

        [OdinSerialize, LabelText("紐付けられるボタン")] protected AButtonBase m_button;

        [OdinSerialize, LabelText("長押しに要求する時間")] protected float m_require;
        
        protected CancellationToken m_token;
        

        protected IChangeSituationHandler m_handler;
        
        public Action ChangeHoldEvent { get; set; }

        public HoldCaptureModules(AButtonBase button) : base(button) {
            m_handler = button.ChangeHandler as IChangeSituationHandler;
            m_token = button.GetCancellationToken();
        }

        /// <summary>
        /// ボタンが押された際の処理
        /// </summary>
        public async override void OnHook() {
            var success = await CaptureHoldInput(m_token);

            if (success) {
                ChangeHoldEvent?.Invoke();
            }
        }


        protected async UniTask<bool> CaptureHoldInput(CancellationToken token) {
            try {
                var result = await UniTask.WhenAny(
                    UniTask.Delay(TimeSpan.FromSeconds(m_require)), 
                    CaptureReleaseInput(token)
                    );

                if (result == 0) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (OperationCanceledException) {
                return false;
            }
            return false;
        }

        protected async UniTask CaptureReleaseInput(CancellationToken token) {
            try {
                var wasInput = false;
                m_handler.ChangeSituationEvent += OnInput;
                
                await UniTask.WaitUntil(() => wasInput == true);

                void OnInput(ButtonSituation input) {
                    if (input != ButtonSituation.Hold) {
                        wasInput = true;
                        m_handler.ChangeSituationEvent -= OnInput;
                    }
                } 
                    
            }
            catch (OperationCanceledException) {
                
            }
        }
    }
}