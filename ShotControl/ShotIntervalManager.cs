using System;
using Cysharp.Threading.Tasks;
using Modules.Utility.Counter;
using Sirenix.OdinInspector;
using UnityCommonModule.ShotControl.Interface;
using UnityEngine;

namespace UnityCommonModule.ShotControl {
    /// <summary>
    /// 射撃間のインターバルを管理するクラス
    /// </summary>
    public class ShotIntervalManager : SerializedMonoBehaviour , IShotableHolder {
        
        [SerializeField] protected IShotHandler m_handler;
        
        /// <summary>
        /// 射撃間のインターバル
        /// </summary>
        [SerializeField] protected float m_interval;
        
        [SerializeField] protected bool m_isInterval = false;
        
        /// <summary>
        /// インターバルの間を管理するカウンタクラス
        /// </summary>
        [SerializeField] protected SecondsNotificator m_notice;

        private void Awake() {
            AddListenerHandler();
        }

        private void OnDestroy() {
            RemoveListenerHandler();
        }
        
        //--------------------API methods---------------------------------------------

        public bool GetShotable() {
            return !m_isInterval;
        }

        public void SetInterval(float interval) {
            m_interval = interval;
        }
        
        //--------------------Create methods------------------------------------------

        protected virtual void CreateNotificator() {
            var token = this.destroyCancellationToken;
            m_notice = new SecondsNotificator(m_interval, token);
            AddListerNotificator();
            m_notice.StartProgress();
        }
        
        //--------------------Dispose Methods----------------------------------------


        protected virtual void DisposeNotificator() {
            RemoveListerNotificator();
            m_notice.StopProgress();
        }
        
        
        //--------------------Listener methods----------------------------------------

        protected void AddListenerHandler() {
            m_handler.ShotUEvent.AddListener(OnShot);
        }

        protected void RemoveListenerHandler() {
            m_handler.ShotUEvent.RemoveListener(OnShot);
        }

        protected void AddListerNotificator() {
            m_notice.NotificationEvent += OnProgressInterval;
        }

        protected void RemoveListerNotificator() {
            m_notice.NotificationEvent -= OnProgressInterval;
        }
        
        //--------------------Hook point methods---------------------------------------

        protected void OnShot() {
            CreateNotificator();
            m_isInterval = true;
        }

        protected void OnProgressInterval() {
            DisposeNotificator();
            m_isInterval = false;
        }
        
        //--------------------Logic methods---------------------------------------------
        
    }
}