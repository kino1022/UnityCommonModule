using System;

namespace UnityCommonModule.ShotControl.Bullet.Reload.Interface {
    /// <summary>
    /// リロード開始を通知するクラスに対して約束するインターフェース
    /// </summary>
    public interface IReloadStartHandler {
        /// <summary>
        /// リロード開始を通知するイベント
        /// </summary>
        public Action ReloadStartEvent { get; set; }
    }
}