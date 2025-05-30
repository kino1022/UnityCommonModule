namespace UnityCommonModule.CharacterMove.Gravity.Interface {
    /// <summary>
    /// 接地状態を保持するクラスに対して約束するインターフェース
    /// </summary>
    public interface IGroundedHolder {
        /// <summary>
        /// 設置しているか否かを取得する
        /// </summary>
        /// <returns></returns>
        public bool GetIsGrounded();
    }
}