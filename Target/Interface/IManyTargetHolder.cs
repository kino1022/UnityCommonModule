using System.Collections.Generic;

namespace UnityCommonModule.Target.Interface {
    /// <summary>
    /// 複数の対象を管理するクラスに対して約束するインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IManyTargetHolder<T>  {
        /// <summary>
        /// 対象になったものをリストで取得するメソッド
        /// </summary>
        /// <returns></returns>
        public List<T> GetTargets();
    }
}