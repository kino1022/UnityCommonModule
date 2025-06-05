using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Always.Interface;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Interface;
using UnityEngine;

namespace UnityCommonModule.Status.Correctable {
    
    /// <summary>
    /// 補正可能なステータスの値を管理するコンポーネント
    /// </summary>
    /// <typeparam name="T">管理する値の変数型</typeparam>
    /// <typeparam name="C">補正値マネージャのデータ型</typeparam>
    public abstract class ACorrectableStatus<T> : AStatus<T>, ICorrectable  {
        
        [SerializeField, OdinSerialize, LabelText("補正後の値")] protected CorrectedStatusValue<T> m_corrected;

        [SerializeField, OdinSerialize, LabelText("補正管理")] protected IAlwaysCorrectionManager m_correction;

        private void Awake() {
            SetUpCorrectionManager();
        }

        private void OnDestroy() {
            RemoveListenerRequire();
        }
        
        #region API Methods

        public override T GetValue() {
            return m_corrected.GetValue();
        }

        public virtual void ExecuteCorrection() {
            ApplyCorrection();
        }

        public void AddCorrection(ACorrection correction) {
            m_correction.AddCorrection(correction);
        }

        public void RemoveCorrection(ACorrection target) {
            m_correction.RemoveCorrection(target);
        }

        #endregion
        
        #region Logic Methods

        /// <summary>
        /// 元の値に対して補正値を適用したものをCorrectedValueに対して代入する
        /// </summary>
        protected abstract void ApplyCorrection();

        #endregion
        
        #region Correction

        protected virtual void SetUpCorrectionManager() {
            AddListenerRequire();
        }

        protected virtual void AddListenerRequire() {
            m_correction.RequireReExecuteEvent += ApplyCorrection;
        }

        protected virtual void RemoveListenerRequire() {
            m_correction.RequireReExecuteEvent -= ApplyCorrection;
        }
        
        #endregion
        
        #region Hook Point

        protected override void OnPostValueChanged() {
            base.OnPostValueChanged();
            ApplyCorrection();
        }

        #endregion

    }
}