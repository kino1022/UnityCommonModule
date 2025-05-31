namespace UnityCommonModule.CharacterMove.Homing.Interface {
    /// <summary>
    /// 誘導率を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IHomingRateHolder {
        /// <summary>
        /// 誘導率を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public float GetHomingRate();
    }
}