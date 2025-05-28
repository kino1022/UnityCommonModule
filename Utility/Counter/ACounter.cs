using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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

        protected float m_timeOut = 200.0f;

        protected bool m_isRunning = false;
        
        //------------------Open Methods----------------------

        public T GetCount() {
            return m_count;
        }
        /// <summary>
        /// 初期状態もしくは停止しているカウンタを始動するメソッド
        /// </summary>
        public void StartProgress() {
            m_isProgress = true;
            if (!m_isRunning) {
                CountTask().Forget();
                m_isRunning = true;
            }
        }
        
        /// <summary>
        /// カウンタを停止させるメソッド
        /// </summary>
        public void StopProgress() {
            m_isProgress = false;
        }
        
        //------------------Hook Point------------------------

        protected virtual T CollectableValue(T value) { return value; }
        
        protected virtual void OnPreCountChange () {}
        
        protected virtual void OnPostCountChange () {}
        
        //-----------------logic methods----------------------------

        protected abstract UniTask CountTask();
        
        /// <summary>
        /// タスクの途中でm_isProgressがfalseになった際に再びtrueになるかタイムアウトするまで待機するタスク
        /// </summary>
        /// <returns></returns>
        protected async UniTask<bool> WaitForReStart(CancellationToken token) {
            try {
                var result = await UniTask.WhenAny(
                    UniTask.WaitUntil(() => m_isProgress),
                    UniTask.Delay(TimeSpan.FromSeconds(m_timeOut))
                    );
                switch (result) {
                    case 1 : return true;
                    default: return false;
                }
            }
            catch (OperationCanceledException) {
                return false;
            }
        } 
    }
}