using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityCommonModule.Input.Button.Definition;
using UnityCommonModule.Input.Button.Interface;
using UnityEngine;
using UnityEngine.LowLevel;

namespace UnityCommonModule.Input.Button {
    [Serializable]
    public class HoldInputObserver {
        
        [SerializeField] protected IChangeSituationHandler m_handler;
        
        /// <summary>
        /// 長押し判定になるのに必要な長押し秒数
        /// </summary>
        [SerializeField] protected float m_requireSeconds;
        
        /// <summary>
        /// 長押し判定の条件を満たした際に発火されるイベント
        /// </summary>
        public Action PhaseHoldEvent;

        protected CancellationToken token;

        public HoldInputObserver(IChangeSituationHandler handler, float requireTime,CancellationToken token) {
            m_handler = handler;
            m_requireSeconds = requireTime;
            this.token = token;
        }
        
        //----------------------API Methods-------------------------------------

        public void ChangeRequireSeconds(float time) {
            m_requireSeconds = time;
        }
        
        //----------------------listener methods---------------------------------

        protected void AddListenerHandler() {
            m_handler.SituationChangeEvent += OnSituationChange;
        }

        protected void RemoveListenerHandler() {
            m_handler.SituationChangeEvent -= OnSituationChange;
        }
        
        //----------------------hook point---------------------------------------

        protected void OnSituationChange(ButtonSituation situation) {
            
        }
        
        //---------------------Logic methods-------------------------------------

       
    }
}