using UnityEngine;

namespace UnityCommonModule.CharacterMove.Interface {
    /// <summary>
    /// 運動ベクトルを算出する際に使用する方向ベクトルを保持するクラスに対して約束するインターフェース
    /// </summary>
    public interface IDirectionHolder {
        /// <summary>
        /// 方向ベクトルを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public Vector3 GetDirection();
    }
}