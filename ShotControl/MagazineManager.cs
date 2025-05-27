using Sirenix.OdinInspector;
using UnityCommonModule.ShotControl.Interface;
using UnityEngine;

namespace Script.UnityCommonModule.ShotControl {
    /// <summary>
    /// 残弾数を管理するコンポーネント
    /// </summary>
    public class MagazineManager : SerializedMonoBehaviour , IShotableHolder {

        [SerializeField] protected int m_maxValue;

        [SerializeField] protected int m_value;
        
        

        public bool GetShotable() {
            return m_value > 0;
        }

    }
}