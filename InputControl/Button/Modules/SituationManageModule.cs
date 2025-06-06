using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Definition;
using UnityCommonModule.InputControl.Button.Interface;

namespace UnityCommonModule.InputControl.Button.Modules {
    /// <summary>
    /// 現在のボタンの状態を管理するクラス
    /// </summary>
    [Serializable]
    public class SituationManageModule : ISituationHolder , IChangeSituationHandler {
        
        [OdinSerialize,LabelText("ボタン状態")] private ButtonSituation _situation = ButtonSituation.None;
        
        [OdinSerialize,LabelText("一つ前のボタン状態")] protected ButtonSituation m_previousSituation;

        public Action<ButtonSituation> ChangeSituationEvent { get; set; }

        protected ButtonSituation m_situation {
            get { return _situation; }
            set {
                value = OnPreChangeSituation(value);
                _situation = value;
                OnPostChangeSituation();
            }
        }

        #region API

        public ButtonSituation GetCurrentSituation() {
            return m_situation;
        }

        public ButtonSituation GetPreviousSituation() {
            return m_previousSituation;
        }

        public void SetSituation(ButtonSituation situation) {
            m_situation = situation;
        }

        #endregion
        
        
        #region Hook

        protected virtual ButtonSituation OnPreChangeSituation(ButtonSituation situation) {
            m_previousSituation = m_situation;
            return situation;
        }

        protected virtual void OnPostChangeSituation() {
            if (m_previousSituation != m_situation) {
                ChangeSituationEvent?.Invoke(m_situation);
            }
        }
        
        #endregion
        
    }
}