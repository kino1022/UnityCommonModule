using System;
using System.Collections.Generic;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction {
    [Serializable]
    public class CorrectionManager : MonoBehaviour, ICorrectionExecutor, IRequireExecuteHandler {
        /// <summary>
        /// 補正値リストのインスタンス
        /// </summary>
        [SerializeReference] protected List<ACorrectionList> m_correctionLists;
        /// <summary>
        /// 補正計算の際の計算順
        /// </summary>
        [SerializeField] protected List<CorrectionType> m_executePriority;

        public Action RequireExecuteEvent { get; set; }

        private void Awake() {
            SetUpList();
        }

        private void OnDestroy() {
            DisposeList();
        }

        //------------------------API Methods-----------------------------------
        
        public float ExecuteCorrection(float value) {
            return CalculateCorrection(value);
        }

        public void AddCorrection(ACorrection correction) {
            var target = GetListFromCorrectionType(correction.Type);
            
            if (target == null) {
                Debug.Log("補正値分類に適格する補正値リストクラスがインスタンスされていないです。お前のコードミスだ。");
                return;
            }
            
            target.AddCorrection(correction);
        }
        
        //------------------------SetUp methods---------------------------------

        protected void SetUpList() {
            foreach (var correctionList in m_correctionLists) {
                AddListenerRequireHandler(correctionList);
            }
        }
        
        //------------------------dispose methods-------------------------------

        protected void DisposeList() {
            foreach (var correctionList in m_correctionLists) {
                RemoveListenerRequireHandler(correctionList);
            }
        }
        
        //------------------------listener methods------------------------------

        protected void AddListenerRequireHandler(IRequireExecuteHandler handler) {
            handler.RequireExecuteEvent += this.RequireExecuteEvent;
        }

        protected void RemoveListenerRequireHandler(IRequireExecuteHandler handler) {
            handler.RequireExecuteEvent -= this.RequireExecuteEvent;
        }
        
        //------------------------hook point methods----------------------------

        protected virtual void OnRequireExecute() {
            RequireExecuteEvent?.Invoke();
        }
        
        //------------------------logic methods---------------------------------

        public float CalculateCorrection(float value) {
            var result = value;

            if (m_correctionLists == null) return result;
            
            foreach (var type in m_executePriority) {
                var list = m_correctionLists.Find(x => x.CorrectionType == type);
                list.ExecuteCorrection(result);
            }
            return result;
        }

        public ACorrectionList GetListFromCorrectionType(CorrectionType correctionType) {
            return m_correctionLists.Find(x => x.CorrectionType == correctionType);
        }
    }
}