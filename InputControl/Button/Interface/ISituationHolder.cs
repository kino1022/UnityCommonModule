using UnityCommonModule.InputControl.Button.Definition;

namespace UnityCommonModule.InputControl.Button.Interface {
    /// <summary>
    /// ボタンの状態を管理するクラスに対して与えるインターフェース
    /// </summary>
    public interface ISituationHolder {
        /// <summary>
        /// 現在のボタンの状態を取得する
        /// </summary>
        /// <returns></returns>
        public ButtonSituation GetCurrentSituation();
    }
}