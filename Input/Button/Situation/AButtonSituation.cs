using UnityCommonModule.Input.Button.Interface;

namespace UnityCommonModule.Input.Button.Situation {
    public abstract class AButtonSituation : IButtonSituation {

        protected IButtonInstance m_button;

        protected AButtonSituation(IButtonInstance button) {
            m_button = button;
        }

        public abstract void StartSituation();

        public abstract void EndSituation();
        
        
        public abstract void OnPress();
        
        public abstract void OnRelease();
    }
}