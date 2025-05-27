namespace UnityCommonModule.ShotControl.Interface {
    /// <summary>
    /// 射撃可能かどうかに関わるクラスに対して約束するインターフェース
    /// </summary>
    public interface IShotableHolder {
        public bool GetShotable();
    }
}