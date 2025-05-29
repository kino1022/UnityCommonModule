using System;
using UnityCommonModule.Target.Interface;
using UnityEngine;

namespace UnityCommonModule.Target {
    /// <summary>
    /// 指定したゲームオブジェクトの指定したコンポーネントを取得するクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class SelfTargetFinder<T> : ScriptableObject , ITargetHolder<T> where T : MonoBehaviour {

        protected GameObject m_master;

        public SelfTargetFinder(GameObject master) {
            m_master = master;
        }

        public T GetTarget() {
            return m_master.GetComponent<T>();
        }
    }
}