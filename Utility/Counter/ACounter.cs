using System;
using UnityEngine;

namespace Modules.Utility.Counter {
    /// <summary>
    /// タイムカウンタなどの時間計測クラスの規定クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class ACounter<T> {
        
        private T count;

        protected T m_count {
            get { return count; }
            set {
                value = CollectableValue(value);
                OnPreCountChange();
                count = value;
                OnPostCountChange();
            }
        }

        protected bool m_isProgress = true;
        
        //------------------Open Methods----------------------

        public T GetCount() {
            return m_count;
        }

        public void ReStartProgress() {
            m_isProgress = true;
        }

        public void StopProgress() {
            m_isProgress = false;
        }
        
        //------------------Hook Point------------------------

        protected virtual T CollectableValue(T value) { return value; }
        
        protected virtual void OnPreCountChange () {}
        
        protected virtual void OnPostCountChange () {}
    }
}