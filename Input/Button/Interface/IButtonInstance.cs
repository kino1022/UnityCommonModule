using UnityCommonModule.Input.Button.Data;

namespace UnityCommonModule.Input.Button.Interface {
    public interface IButtonInstance {
        
        public ButtonData Data { get; }
        
        public void SetSituation(IButtonSituation situation);
        
        
    }
}