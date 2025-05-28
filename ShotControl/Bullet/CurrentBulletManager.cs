using System;
using Sirenix.OdinInspector;
using UnityCommonModule.ShotControl.Bullet.Interface;
using UnityCommonModule.ShotControl.Interface;
using UnityEngine;

namespace UnityCommonModule.ShotControl.Bullet {
    public class CurrentBulletManager : SerializedMonoBehaviour , ICurrentBulletHolder , IShotableHolder {
        
        [SerializeField] private int _currentBullet;

        protected int m_currentBullet {
            get { return _currentBullet; }
            set {
                _currentBullet = value;
                OnPostChangeBullet();
            }
        }
        
        [SerializeField] protected IShotHandler m_shotHandler;

        [SerializeField] protected IConsumeBulletHolder m_consumeHolder;

        [SerializeField] protected IMaxBulletHolder m_maxBullet;

        private void Awake() {
            m_shotHandler = GetComponent<IShotHandler>();
            m_consumeHolder = GetComponent<IConsumeBulletHolder>();
            m_maxBullet = GetComponent<IMaxBulletHolder>();
            AddListenerHandler();
        }


        //---------------API methods----------------------------

        public int GetCurrentBulletCount() {
            return m_currentBullet;
        }

        public bool GetShotable() {
            return m_consumeHolder.GetConsumeBullet() < m_currentBullet;
        }

        public void ReloadBullet() {
            m_currentBullet = m_maxBullet.GetMaxBulletCount();
        }

        public void IncreaseBullet(int amount) {
            m_currentBullet += amount;
        }

        public void DecreaseBullet(int amount) {
            m_currentBullet -= amount;
        }
        
        //---------------Listener methods-----------------------

        protected virtual void AddListenerHandler() {
            m_shotHandler.ShotUEvent.AddListener(OnShot);
        }
        
        //---------------Hook Point-----------------------------

        protected virtual void OnShot() {
            if (!GetShotable()) {
                Debug.LogError("射撃不能のはずなのに射撃イベントが発火されました");
                return;
            }
        }

        protected virtual void OnPostChangeBullet() {
            if (_currentBullet > m_maxBullet.GetMaxBulletCount()) {
                Debug.Log("代入された段数が最大数を超過しているため、最大数に補正します");
                _currentBullet = m_maxBullet.GetMaxBulletCount();
            }

            if (_currentBullet < 0) {
                Debug.Log("弾数が負の象限で代入されたため、0に補正します");
                _currentBullet = 0;
            }
            
            
        }
        
        
    }
}