using R3;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Interface;
using UnityCommonModule.Status.Module;
using UnityEngine;

namespace UnityCommonModule.Status {
    public abstract class ACorrectableStatus<T,C> : AStatus<T,C>, ICorrectableStatus<T> where C : ICalculator<T> ,new(){

        protected CorrectedValueModule<T> m_corrected;

        public IValueHolder<T> Corrected => m_corrected;

        protected CorrectionManager m_correction = new CorrectionManager();

        public ICorrector Correction => m_correction;

        [OdinSerialize, LabelText("現在の値")]
        public override T Get => m_corrected.Get();

        /// <summary>
        /// 補正値を適用するメソッド
        /// </summary>
        protected void ApplyCorrection() {
            m_corrected.Set(m_calculator.ApplyCorrection(m_rawValue.Get(), m_correction));
        }

        protected override void OnInitialize() {
            base.OnInitialize();
            m_corrected = new CorrectedValueModule<T>(m_data.InitialValue);
            RegisterObserveRawValue();

            m_correction.Handler.ReExecuteEvent += ApplyCorrection;
        }

        protected virtual void OnPostRawValueChange() {
            ApplyCorrection();
            Debug.Log("補正値を適用しました");
        }

        protected void RegisterObserveRawValue() {
            Observable.EveryValueChanged(m_rawValue, x => x.Get()).Subscribe(x => {
                Debug.Log("元の値の変化を検知しました");
                OnPostRawValueChange();
            });
        }

    }
}
