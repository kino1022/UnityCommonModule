using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.InputControl.Button.Modules;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityCommonModule.InputControl.Button.Data {
    /// <summary>
    /// ボタンのデータを初期化するためのオブジェクト
    /// </summary>
    [CreateAssetMenu(menuName = "UnityCommonModule/InputControl/Button/InitializeData")]
    public class ButtonInitializeData : SerializedScriptableObject {
        
        [LabelText("ボタンのID")]　public int m_ID;
        
        [LabelText("ボタンの名前")] public string m_Name;
        
        [LabelText("対応するアクションマップ")] public InputAction m_ActionMap;

        [SerializeField,OdinSerialize,LabelText("押された際の処理フック"),BoxGroup("フック")]　
        public List<AHook> OnPressHooks;
        
        [SerializeField,OdinSerialize,LabelText("長押しされた際の処理フック"),BoxGroup("フック")]
        public List<AHook> OnHoldHook;
        
        [SerializeField, OdinSerialize,LabelText("離された際の処理フック"),BoxGroup("フック")]
        public List<AHook> OnReleaseHook;

    }
}