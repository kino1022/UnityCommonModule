using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityCommonModule.ShotControl.Interface;
using UnityEngine;

namespace UnityCommonModule.ShotControl {
    public class ShotIntervalManager : SerializedMonoBehaviour , IShotableHolder {
        
        [SerializeField] protected IShotHandler m_handler;
        
        /// <summary>
        /// 射撃間のインターバル
        /// </summary>
        [SerializeField] protected float m_interval;
        
        [SerializeField] protected bool m_isInterval = false;

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
        
        //--------------------Listener methods----------------------------------------

        protected void AddListenerHandler() {
            m_handler.ShotUEvent.AddListener(OnShot);
        }

        protected void RemoveListenerHandler() {
            m_handler.ShotUEvent.RemoveListener(OnShot);
        }
        
        //--------------------Hook point methods---------------------------------------

        protected void OnShot() {
            
        }
        
        //--------------------Logic methods---------------------------------------------


    }
}