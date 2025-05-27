using System;
using Script.UnityCommonModule.Condition.Definition;
using Script.UnityCommonModule.Condition.Interface;
using UnityEngine;

namespace Script.UnityCommonModule.Condition {
    /// <summary>
    /// 論理演算子の絡む条件を管理するクラス
    /// </summary>
    [Serializable]
    [CreateAssetMenu(menuName = "CommonModules/Condition/LogicalCondition", fileName = "LogicalCondition")]
    public class LogicalCondition : ACondition {
        
        protected IConditionHolder m_conditionA;
        protected IConditionHolder m_conditionB;
        protected LogicalOperator m_operator;
        
        protected override bool CalculateCondition() {
            var ansA = m_conditionA == null ? true : m_conditionA.GetCondition();
            var ansB = m_conditionB == null ? true : m_conditionB.GetCondition();

            if (m_operator == LogicalOperator.AND) return ansA && ansB;
            else if (m_operator == LogicalOperator.OR) return ansA || ansB;
            else if (m_operator == LogicalOperator.NOT) return !ansA && !ansB;
            else return false;
        }
    }
}