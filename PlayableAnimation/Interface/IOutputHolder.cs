using UnityEngine;
using UnityEngine.Animations;

namespace UnityCommonModule.PlayableAnimation.Interface
{
    /// <summary>
    /// AnimationPlayableOutputを持っているクラスに対して約束するインターフェース
    /// </summary>
    public interface IOutputHolder
    {
        /// <summary>
        /// AnimationPlayableOutputを取得するメソッド
        /// </summary>
        /// <returns></returns>
        public AnimationPlayableOutput GetPlayableOutput();
    }
}