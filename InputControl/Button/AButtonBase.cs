using System;
using System.Collections.Generic;
using System.Threading;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Data;
using UnityCommonModule.InputControl.Button.Definition;
using UnityCommonModule.InputControl.Button.Interface;
using UnityCommonModule.InputControl.Button.Modules;
using UnityCommonModule.InputControl.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Button {
    [Serializable]
    public class AButtonBase : IDisposable{

        [OdinSerialize, LabelText("初期化用データ")] 
        protected ButtonInitializeData m_data;
        

        [SerializeField, OdinSerialize, LabelText("ボタン状態管理クラス")]
        protected SituationManageModule m_situation = new SituationManageModule();
        
        [SerializeField, OdinSerialize, LabelText("ホールド遷移管理")]
        protected HoldCaptureModules m_holdModule;
        
        public ISituationHolder Situation => m_situation;
        public IChangeSituationHandler ChangeHandler => m_situation;
        
        public IHoldHandler HoldHandler => m_holdModule;
        
        protected CancellationTokenSource m_cts = new CancellationTokenSource();

        public AButtonBase(ButtonInitializeData data) {
            m_data = data;
            CancellationToken token = m_cts.Token;
        }


        public void Dispose() {
            DisposeCTS();
        }
        

        #region API

        public CancellationToken GetCancellationToken() {
            return m_cts.Token;
        }

        #endregion
        
        #region Open Class

        public ButtonInitializeData Data => m_data;

        #endregion
        
        
        #region Dispose
        
        protected void DisposeCTS() {
            m_cts.Cancel();
            m_cts.Dispose();
        }
        
        #endregion
        
    }
}