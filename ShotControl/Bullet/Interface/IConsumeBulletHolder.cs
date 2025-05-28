namespace UnityCommonModule.ShotControl.Bullet.Interface {
    /// <summary>
    /// 一度の射撃で消費する弾数を保持するインターフェース
    /// </summary>
    public interface IConsumeBulletHolder {
        public int GetConsumeBullet();
    }
}