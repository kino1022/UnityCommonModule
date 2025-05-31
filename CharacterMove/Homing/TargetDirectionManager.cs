using Sirenix.OdinInspector;
using UnityCommonModule.CharacterMove.Interface;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace UnityCommonModule.CharacterMove.Homing {
    /// <summary>
    /// ターゲットの方向を管理するコンポーネント
    /// </summary>
    public class TargetDirectionManager : SerializedMonoBehaviour , IDirectionHolder {
        
        [SerializeField] protected ITargetHolder<Transform> m_target;
        
        
        public Vector3 GetDirection() {
            var target = m_target.GetTarget().transform.position;

            if (target == null) {
                return Vector3.zero;
            }
            
            return (target - transform.position).normalized;
        }
    }
}