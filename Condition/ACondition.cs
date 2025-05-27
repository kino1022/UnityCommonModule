using System;
using Script.UnityCommonModule.Condition.Interface;
using UnityEngine;

namespace Script.UnityCommonModule.Condition {
    /// <summary>
    /// 単一条件を管理するクラスの基底クラス
    /// </summary>
    [Serializable]
    public abstract class ACondition : ScriptableObject, IConditionHolder {
        
        /// <summary>
        /// 真偽値の算出を行うメソッド
        /// </summary>
        /// <returns></returns>
        protected virtual bool CalculateCondition() {
            return false;
        }
        
        public bool GetCondition() {
            return CalculateCondition();
        }
    }
}