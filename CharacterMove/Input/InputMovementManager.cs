using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace UnityCommonModule.CharacterMove.Input {
    /// <summary>
    /// キャラクターの移動などによって生じる運動量を管理するコンポーネント
    /// </summary>
    public class InputMovementManager : AMovementManager {
        
        [SerializeField] private IDirectionHolder m_direction;
        
        [SerializeField] private IForceHolder m_force;
        
        //--------------API methods----------------------------

        public override Vector3 GetMovement() {
            return CalculateMovement();
        }

        //--------------logical methods-------------------------

        protected virtual Vector3 CalculateMovement() {
            return m_direction.GetDirection() * m_force.GetForce();
        }
    }
}