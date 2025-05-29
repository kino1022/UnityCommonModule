namespace UnityCommonModule.CharacterMove.Interface {
    /// <summary>
    /// 運動ベクトルを示す際に方向ベクトルと掛け合わせる運動量を保持するクラスに約束するインターフェース
    /// </summary>
    public interface IForceHolder {
        /// <summary>
        /// 運動量を取得する
        /// </summary>
        /// <returns></returns>
        public float GetForce();
    }
}