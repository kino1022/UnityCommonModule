using System;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrection : IDisposable {
        
        /// <summary>
        /// 補正値の計算方法の分類
        /// </summary>
        public ICorrectionType Type { get; }
        
        /// <summary>
        /// 補正値の値
        /// </summary>
        public float Value { get; }
        
        /// <summary>
        /// 補正値が有効かどうか
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// 補正値が使用された際に呼び出されるメソッド
        /// </summary>
        public void OnExecuted();

    }
}