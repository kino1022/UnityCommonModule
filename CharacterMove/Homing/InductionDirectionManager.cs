using System;
using System.Security;
using Sirenix.OdinInspector;
using UnityCommonModule.CharacterMove.Homing.Interface;
using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace UnityCommonModule.CharacterMove.Homing {
    public class InductionDirectionManager : SerializedMonoBehaviour , IDirectionHolder {

        [SerializeField] private Vector3 _direction;

        protected Vector3 m_direction {
            get { return _direction; }
            set {
                _direction = value;
                OnChangeDirection(_direction);
                DirectionChangeEvent?.Invoke(_direction);
            }
        }

        [SerializeField] protected IHomingRateHolder m_vertical;
        
        [SerializeField] protected IHomingRateHolder m_horizontal;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] protected IDirectionHolder m_targetDirection;
        
        public Action<Vector3> DirectionChangeEvent { get; set; }
        
        //------------------------------API methods-----------------------

        public Vector3 GetDirection() {
            return m_direction;
        }

        public void SetDirection(Vector3 dir) {
            m_direction = dir;
        }

        public void ApplicationHoming() {
            m_direction = BlendDirection(m_targetDirection.GetDirection());
        }
        
        
        //------------------------------Hook point------------------------

        protected virtual void OnChangeDirection(Vector3 direction) {
            
        }
        
        //-----------------------------logical methods-------------------

        protected virtual Vector3 BlendDirection(Vector3 dir) {
            return new Vector3(
                dir.x * m_horizontal.GetHomingRate() + _direction.x * (1 - m_horizontal.GetHomingRate()),
                dir.y * m_vertical.GetHomingRate() + _direction.y * (1 - m_vertical.GetHomingRate()), 
                dir.z * m_horizontal.GetHomingRate() + _direction.z * (1 - m_horizontal.GetHomingRate())
                ).normalized;
        }
    }
}