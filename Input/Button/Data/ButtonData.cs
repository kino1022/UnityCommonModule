using Sirenix.OdinInspector;
using UnityCommonModule.Input.Button.Context;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UnityCommonModule.Input.Button.Data {
    public class ButtonData : SerializedScriptableObject {
        
        [SerializeField, LabelText("入力内容")] 
        public InputActionMap Input;

        [SerializeField, LabelText("")] 
        public UnityAction<InputContext> Action;

        [SerializeField, LabelText("長押し判定に要求する押下時間"), ProgressBar(0, 5.0f)]
        public float HoldTime = 0.2f;
    }
}
