using System.Collections.Generic;
using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace UnityCommonModule.CharacterMove {
    /// <summary>
    /// 複数のImovementHolderから取得した運動量を合計して管理するコンポーネント
    /// </summary>
    public class TotalMovementManager : AMovementManager {
        
        [SerializeField] protected List<IMovementHolder> m_movements;

        private void Update() {
            m_movement = CalculationTotalMovement();
        }
        
        //----------------logic methods----------------------------------

        protected Vector3 CalculationTotalMovement () {
            var result = Vector3.zero;
            foreach (var movement in m_movements) {
                result += movement.GetMovement();
            } 
            return result;
        }
    }
}