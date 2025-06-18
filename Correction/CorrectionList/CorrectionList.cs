using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ObservableCollections;
using UnityCommonModule.Correction.Interface;
using UnityEngine;
using R3;
using UnityCommonModule.Correction.Module;

namespace UnityCommonModule.Correction {
    public class CorrectionList : ICorrectionList , IReExecuteHandler {
        
        protected ICorrectionType m_type;
        
        public ICorrectionType Type => m_type;

        protected ObservableList<ICorrection> m_corrections = new ObservableList<ICorrection>();
        
        public IReadOnlyObservableList<ICorrection> List => m_corrections;

        protected CorrectionObserveModule m_observer;
        
        public Action ReExecuteEvent { get; set; }

        public CorrectionList(ICorrectionType type) {
            m_type = type;
            m_observer = new CorrectionObserveModule(m_corrections);
            AddListenerObserver();
        }

        public void Add(ICorrection correction) {
            
            if (m_type.GetType() != correction.Type.GetType()) {
                Debug.LogError("計算方式の異なる補正値が追加されました、追加処理を中断します");
                return;
            }
            
            m_corrections.Add(correction);
            ReExecuteEvent?.Invoke();
        }

        public void Remove(ICorrection correction) {
            var target = m_corrections.Where(x => x == correction).FirstOrDefault();
            
            if (target == null) {
                Debug.LogError("除外対象に指定された補正値のインスタンスがリストに存在しませんでした");
                return;
            }
            
            m_corrections.Remove(correction);
            ReExecuteEvent?.Invoke();
        }

        public float Calculate(float value) {
            return m_type.Calculate(value, m_corrections.ToList());
        }

        protected void AddListenerObserver() {
            m_observer.DisposeEvent += OnCorrectionDispose;
            m_observer.ReExecuteEvent += OnCorrectionValueChanged;
        }


        protected void OnCorrectionValueChanged() {
            ReExecuteEvent?.Invoke();
        }

        protected virtual void OnCorrectionDispose(ICorrection correction) {
            Remove(correction);
        }

        public void OnExecuted() {
            foreach (var correction in m_corrections) {
                correction.OnExecuted();
            }
        }
    }
}