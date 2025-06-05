using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Strategy;
using UnityCommonModule.Correction.Strategy.Interface;
using UnityCommonModule.Status.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction {
    /// <summary>
    /// 補正値の分類ごとに補正値を管理するクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class ACorrectionList<C> where C : ACorrection {
        
        [OdinSerialize,LabelText("管理する補正値の分類")] 
        protected CorrectionType m_type;
        
        [OdinSerialize,SerializeField,LabelText("管理している補正値")] 
        protected List<C> m_corrections = new List<C>();

        public ACorrectionList(CorrectionType type) {
            m_type = type;
        }

        #region API Methods

        public virtual float ExecuteCorrection(float value) {
            
            ICalculateStrategy<C> str = GetCalculateStrategy();

            return str.ApplyCorrection(value);
        }

        public virtual void AddCorrection(C correction) {

            if (!GetAddable(correction)) {
                return;
            }
            
            m_corrections.Add(correction);
            AddListenerCorrection(correction);
        }

        public virtual void RemoveCorrection(C correction) {
            m_corrections.Remove(correction);
            RemoveListenerCorrection(correction);
        }

        public CorrectionType GetCorrectionType() {
            return m_type;
        }

        public ACorrection GetAnyCorrection(C correction) {
            return m_corrections.Find(x => x == correction);
        }

        #endregion
        
        #region Listener

        protected virtual void AddListenerCorrection(C correction) {
            correction.DisposeEvent += OnCorrectionDispose;
        }

        protected virtual void RemoveListenerCorrection(C correction) {
            correction.DisposeEvent -= OnCorrectionDispose;
        }
        
        
        #endregion
        
        
        #region HookPoint

        protected virtual void OnCorrectionDispose(ACorrection correction) {
            if (correction is C cor) {
                RemoveCorrection(cor);
            }
        }
        
        #endregion
        
        #region Logical

        protected virtual bool GetAddable(ACorrection correction) {
            
            if (correction.GetCorrectionType() != m_type) {
                return false;
            }
            
            return true;
        }

        protected virtual float CalculateTotalValue() {
            var str = GetCalculateStrategy();
            return str.CalculateTotalValue();
        }

        protected virtual ICalculateStrategy<C> GetCalculateStrategy() {
            if (m_type == CorrectionType.Fixed) {
                return new FixedCalculateStrategy<C>(ref m_corrections);
            }
            else if (m_type == CorrectionType.Ratio) {
                return new RatioCalculateStrategy<C>(ref m_corrections);
            }
            
            return null;
        }

        #endregion
    }
}