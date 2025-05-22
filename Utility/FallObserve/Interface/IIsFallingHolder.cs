namespace UnityCommonModule.FallObserve.Interface {
    /// <summary>
    /// 現在落下しているかどうかを保持しているクラスに対して約束するインターフェース
    /// </summary>
    public interface IIsFallingHolder {
        /// <summary>
        /// 現在落下中かどうかを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public bool GetIsFalling();
    }
}