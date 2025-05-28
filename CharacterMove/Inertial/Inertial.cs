using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules.Utility.Counter;
using UnityCommonModule.CharacterMove.Interface;
using UnityEngine;

namespace UnityCommonModule.CharacterMove.Inertial {
    public class Inertial : IMovementHolder {
        /// <summary>
        /// 慣性の働く方向
        /// </summary>
        protected Vector3 m_direction;
        
        /// <summary>
        /// 慣性の強さ
        /// </summary>
        protected float m_force;

        /// <summary>
        /// 慣性の減衰率
        /// </summary>
        protected float m_dumping;
        
        /// <summary>
        /// タスクのキャンセルを使用するトークン
        /// </summary>
        protected CancellationToken m_token;
        
        
        protected SecondsInvoker m_inveker;

        public Action<Inertial> DisposeEvent;

        public Inertial(Vector3 direction, float force, float dumping, CancellationToken token) {
            m_direction = direction;
            m_force = force;
            m_dumping = dumping;
            m_token = token;

            m_inveker = new SecondsInvoker(0.1f, DampingInertial, m_token);
            m_inveker.StartProgress();
        }
        
        //----------------------API Methods-----------------------------

        public Vector3 GetMovement() {
            return CalculateMovement();
        }
        
        //----------------------Dispose methods-------------------------

        protected void DisposeInvoker() {
            m_inveker.StopProgress();
        }
        
        //----------------------logical methods--------------------------

        protected Vector3 CalculateMovement() {
            return m_direction * m_force;
        }

        protected void DampingInertial() {
            m_force *= m_dumping;
            if (m_force <= 0.001f) {
                DisposeInvoker();
                DisposeEvent?.Invoke(this);
            }
        }
        
    }
}