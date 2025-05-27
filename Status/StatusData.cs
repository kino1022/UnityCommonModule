using UnityEngine;

namespace UnityCommonModule.Status {
    /// <summary>
    /// ステータスの初期値などをDIするためのデータクラス
    /// </summary>
    [CreateAssetMenu(menuName = "CommonModules/Status/StatusData")]
    public class StatusData : ScriptableObject {
        public float Value;
        public bool AllowMinus = false;
    }
}