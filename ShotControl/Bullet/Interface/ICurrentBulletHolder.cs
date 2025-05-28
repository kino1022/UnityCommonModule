namespace UnityCommonModule.ShotControl.Bullet.Interface {
    /// <summary>
    /// 現在の段数を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ICurrentBulletHolder {
        /// <summary>
        /// 現在の弾数を取得するメソッド
        /// </summary>
        /// <returns></returns>
        public int GetCurrentBulletCount();
        
        
        /// <summary>
        /// 段数を全開させるメソッド
        /// </summary>
        public void ReloadBullet();
        
        /// <summary>
        /// 弾数を引数分増加させるメソッド
        /// </summary>
        public void IncreaseBullet(int amount);
        /// <summary>
        /// 弾数を引数分減少させるメソッド
        /// </summary>
        public void DecreaseBullet(int amount);
    }
}