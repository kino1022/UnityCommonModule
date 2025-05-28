using UnityCommonModule.ShotControl.Bullet.Interface;

namespace UnityCommonModule.ShotControl.Bullet.Reload.Interface {
    /// <summary>
    /// リロード処理を実行するクラスに対して約束するインターフェース
    /// </summary>
    public interface IReloadExecutor {
        /// <summary>
        /// リロードを実行するメソッド
        /// </summary>
        /// <param name="holder"></param>
        public void ExecuteReload(ICurrentBulletHolder holder);
    }
}