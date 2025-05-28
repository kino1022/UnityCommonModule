namespace UnityCommonModule.ShotControl.Bullet.Interface {
    /// <summary>
    /// 弾数の最大値を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IMaxBulletHolder {
        /// <summary>
        /// 最大の弾数を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public int GetMaxBulletCount();
        
    }
}