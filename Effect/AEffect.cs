using System.Collections.Generic;
using Script.UnityCommonModule.Condition.Interface;
using Sirenix.OdinInspector;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace UnityCommonModule.Effect {
    /// <summary>
    /// スキルなどの効果を管理するScriptableObject
    /// </summary>
    public class AEffect<T> : SerializedScriptableObject {
        
        [SerializeField] protected T m_target;
        
        //--------------------API Methods----------------
        
        /// <summary>
        /// 効果を発動させる処理
        /// </summary>
        public virtual void OnActivate() {
            
        }
        
        /// <summary>
        /// 発動している効果を無効化する処理(継続していない処理には定義しない)
        /// </summary>
        public virtual void OnDeactivate() {
            
        }

        public void SetTarget(T target) {
            m_target = target;
        }

        public void RemoveTarget() {
            m_target = default(T);
        }
        
        //--------------------logical methods--------------
        
    }
}