namespace Script.UnityCommonModule.Condition.Interface {
    /// <summary>
    /// 真偽値での条件を管理するクラスに対して約束するインターフェース
    /// </summary>
    public interface IConditionHolder {
        /// <summary>
        /// 条件を取得する
        /// </summary>
        /// <returns></returns>
        public bool GetCondition();
    }
}