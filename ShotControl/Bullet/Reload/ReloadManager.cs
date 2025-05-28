using Sirenix.OdinInspector;
using UnityCommonModule.ShotControl.Bullet.Interface;
using UnityCommonModule.ShotControl.Bullet.Reload.Interface;
using UnityEngine;

namespace UnityCommonModule.ShotControl.Bullet.Reload {
    /// <summary>
    /// 弾数のリロードを管理するコンポーネント
    /// </summary>
    public class ReloadManager : SerializedMonoBehaviour {
        
        [SerializeField] protected ICurrentBulletHolder m_bulletHolder;
        
        [SerializeField] protected IReloadStartHandler m_startHandler;
        
        [SerializeField] protected IReloadExecutor m_executor;

        private void Awake() {
            
        }
        
        //---------------------API methods----------------------------------
        
        /// <summary>
        /// 条件を全て無視して強制的にリロードするメソッド
        /// </summary>
        [Button("強制装填")]
        public void ForceReload() {
            m_executor.ExecuteReload(m_bulletHolder);
        }
        
        //---------------------Listener methods-----------------------------

        protected void AddListenerHandler() {
            m_startHandler.ReloadStartEvent += OnReloadStart;
        }

        protected void RemoveListenerHandler() {
            m_startHandler.ReloadStartEvent -= OnReloadStart;
        }
        
        //---------------------Hook point----------------------------------

        protected void OnReloadStart() {
            m_executor.ExecuteReload(m_bulletHolder);
        }
    }
}