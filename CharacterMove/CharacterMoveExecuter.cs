using Script.UnityCommonModule.CharacterMove.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.UnityCommonModule.CharacterMove {
    /// <summary>
    ///  CharacterController.Moveによる実移動をIMovementHolderによる移動量を参照して実際に移動させるコンポーネント
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMoveExecuter : SerializedMonoBehaviour {
        
        [SerializeField] protected CharacterController m_cc;
        
        [SerializeField] protected IMovementHolder m_finnalyMovement;

        private void LateUpdate() {
            m_cc.Move(m_finnalyMovement.GetMovement() * Time.deltaTime);
        }
        
        
    }
}