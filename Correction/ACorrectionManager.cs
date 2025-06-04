using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction {
    [Serializable]
    public class ACorrectionManager<C> : ICorrectionManager where C : ACorrection {

        [SerializeField, OdinSerialize] 
        protected List<ACorrectionList<C>> m_list;

        [SerializeField, OdinSerialize,LabelText("計算の際の計算順")] 
        protected List<CorrectionType> m_priority = new List<CorrectionType>() { CorrectionType.Fixed, CorrectionType.Ratio };
        
        
        #region API Methods

        public float ExecuteCorrection(float value) {
            return CalculateCorrection(value);
        }

        public void AddCorrection(ACorrection correction) {
            foreach (var list in m_list) {
                
                if (list.GetCorrectionType() != correction.GetCorrectionType()) {
                    continue;
                }

                if (correction is C cor) {
                    list.AddCorrection(cor);
                }
            }
        }

        public void RemoveCorrection(ACorrection correction) {
            foreach (var list in m_list) {

                if (correction is C cor) {
                    var result = list.GetAnyCorrection(cor);

                    if (result == null) {
                        continue;
                    }

                    list.RemoveCorrection(cor);
                }
            }
        }
        
        #endregion
        
        #region Logical methods
        
        /// <summary>
        /// 補正済みの値を計算するメソッド
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual float CalculateCorrection(float value) {
            
            var result = value;

            for (int i = 0; i < m_priority.Count; i++) {
                
                var list = m_list.Find(x => x.GetCorrectionType() == m_priority[i]);

                if (list == null) {
                    continue;
                }

                result = list.ExecuteCorrection(value);
            }
            
            return result;
        }
        
        #endregion
    }
}