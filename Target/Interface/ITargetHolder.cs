namespace UnityCommonModule.Target.Interface {
    /// <summary>
    /// 対象を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface ITargetHolder<T> {
        public T GetTarget();
    }
}