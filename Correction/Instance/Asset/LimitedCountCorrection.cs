using System;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction.Instance.Asset {
    /// <summary>
    /// 基本的な回数制限付きの補正値
    /// </summary>
    public class LimitedCountCorrection : ACorrection {

        private int _count = Mathf.Min(0, 0);

        protected int m_count {
            get => _count;
            set {
                _count = value;
                OnCountChanged();
            }
        }

        public LimitedCountCorrection(int count, ICorrectionType type, float value) : base(type, value) {
            
            if (count <= 0) {
                Debug.LogError("使用回数が0回以下で初期化されました");
                return;
            }
            
            m_count = count;
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