using UnityEngine;

namespace UnityCommonModule.CharacterMove.Interface {
    /// <summary>
    /// 運動量を管理するインターフェースに対して約束するインターフェース
    /// </summary>
    public interface IMovementHolder {
        public Vector3 GetMovement();
    }
}