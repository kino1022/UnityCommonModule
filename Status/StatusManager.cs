using Sirenix.OdinInspector;
using UnityCommonModule.Correction;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Status {
    public class StatusManager : SerializedMonoBehaviour {
        
        [SerializeField] protected BaseValue m_baseValue;
        
        [SerializeField] protected CorrectedValue m_correctedValue;
        
        [SerializeField] protected CorrectionManager m_correction;
        
        [SerializeField] protected StatusData m_statusData;
        
        /// <summary>
        /// 参照された際にマイナスの値を許容するかどうか
        /// </summary>
        [SerializeField] protected bool m_allowminus = false;


        private void Awake() {
            SetUpFromData();
            AddListenerRequireExecute(m_correction);
        }
        
        //--------------------API Methods---------------------------------------

        public void SetValue(float value) {
            m_baseValue.SetValue (value);
            ExecuteCorrection();
        }

        public void AddValue(float value) {
            m_baseValue.AddValue (value);
            ExecuteCorrection();
        }

        public float GetValue() {
            return m_correctedValue.GetValue ();
        }
        
        //--------------------SetUp methods------------------------------------

        protected virtual void SetUpFromData() {
            m_allowminus = m_statusData.AllowMinus;
            SetUpElement(m_statusData.Value);
        }

        protected virtual void SetUpElement(float value) {
            m_baseValue = new BaseValue (value, m_allowminus);
            m_correctedValue = new CorrectedValue (value, m_allowminus);
            SetValue(value);
        }
        
        //--------------------Listener methods----------------------------------

        protected void AddListenerRequireExecute(IRequireExecuteHandler handler) {
            handler.RequireExecuteEvent += OnRequireExecute;
        } 
        
        //--------------------Logical methods----------------------------------

        protected virtual void OnRequireExecute() {
            ExecuteCorrection();
        }

        protected virtual void ExecuteCorrection() {
            m_correctedValue.SetValue(
                m_correction.ExecuteCorrection(
                    m_baseValue.GetValue()
                    )
                );
        }
    }
}