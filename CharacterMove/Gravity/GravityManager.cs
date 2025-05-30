using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityCommonModule.CharacterMove.Gravity {
    public class GravityManager : AMovementManager {
        /// <summary>
        /// 重力の強さ
        /// </summary>
        [SerializeField] protected float m_force = 9.81f;
        
        /// <summary>
        /// 重力のかかる方向
        /// </summary>
        [SerializeField] protected Vector3 m_direction = new Vector3(0, -1.0f, 0);
        
        
        //----------------------------API methods------------------------------

        public override Vector3 GetMovement() {
            return CalculateMovement();
        }

        //----------------------------logical methods--------------------------

        protected virtual Vector3 CalculateMovement() {
            return m_direction * m_force;
        }
    }
}