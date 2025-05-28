using UnityCommonModule.CharacterMove.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityCommonModule.CharacterMove {
    public abstract class AMovementManager : SerializedMonoBehaviour , IMovementHolder {
        
        /// <summary>
        /// 管理している運動量
        /// </summary>
        [SerializeField] private Vector3 _movement;

        protected Vector3 m_movement {
            get { return _movement; }
            set {
                value = OnCorrectableValue(value);
                OnPreChangeMovement();
                _movement = value;
                OnPostChangeMovement();
            }
        }
        /// <summary>
        /// 閾値に従って運動量を丸めるかどうか
        /// </summary>
        [SerializeField] protected bool m_wasRounding;
        /// <summary>
        /// 運動量を丸める際の閾値
        /// </summary>
        [SerializeField] protected Vector3 m_threshold;
        
        //------------------Interface methods--------------------------
        public virtual Vector3 GetMovement() {
            return m_movement;
        }
        
        //------------------fuck point----------------------------------

        protected virtual Vector3 OnCorrectableValue(Vector3 input) {
            var result = input;
            result = RoundingMovement(input);
            return result;
        }
        
        protected virtual void OnPreChangeMovement() {}
        
        protected virtual void OnPostChangeMovement() {}
        
        //------------------logic methods-------------------------------
        
        /// <summary>
        /// 与えられた運動量を閾値に従って丸めるメソッド
        /// </summary>
        /// <param name="movement"></param>
        /// <returns></returns>
        protected Vector3 RoundingMovement(Vector3 movement) {
            var result = movement;
            if (Mathf.Abs(movement.x) > Mathf.Abs(m_threshold.x)) movement.x = 0;
            if (Mathf.Abs(movement.y) > Mathf.Abs(m_threshold.y)) movement.y = 0;
            if (Mathf.Abs(movement.z) > Mathf.Abs(m_threshold.z)) movement.z = 0;
            return result;
        }
    }
}