using UnityEngine.Events;

namespace UnityCommonModule.ShotControl.Interface {
    /// <summary>
    /// 射撃した事を通知するクラスに対して約束するインターフェース
    /// </summary>
    public interface IShotHandler {
        /// <summary>
        /// 射撃した際に発火されるイベント
        /// </summary>
        public UnityEvent ShotUEvent {get; set;}
    }
}