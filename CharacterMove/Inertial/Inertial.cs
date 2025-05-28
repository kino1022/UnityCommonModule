using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
        
        //----------------------API Methods-----------------------------

        public Vector3 GetMovement() {
            return CalculateMovement();
        }
        
        //----------------------logical methods--------------------------

        protected Vector3 CalculateMovement() {
            return m_direction * m_force;
        }

        protected async UniTask DampingInertial() {
            while (m_token.IsCancellationRequested) {
                try {
                    
                }
                catch (OperationCanceledException) {
                    break;
                }
            }
        }
    }
}