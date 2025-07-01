using System;
using Sirenix.OdinInspector;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction.Instance.Asset {
    /// <summary>
    /// 基本的な回数制限付きの補正値
    /// </summary>
    [Serializable]
    public class LimitedCountCorrection : ACorrection {

        [SerializeField, LabelText("適用回数")]
        private int _count = Mathf.Min(0, 0);

        protected int m_count {
            get => _count;
            set {
                _count = value;
                OnCountChanged();
            }
        }
        

        public override void OnExecuted() {
            m_count--;
        }

        protected virtual void OnCountChanged() {
            
            if (m_count <= 0) {
                Dispose();
                return;
            }
            
        }
    }
}