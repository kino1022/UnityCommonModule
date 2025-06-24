using UnityCommonModule.Input.Button.Interface;

namespace UnityCommonModule.Input.Button.Situation {
    public class NoneSituation : AButtonSituation {

        public NoneSituation(IButtonInstance button) : base(button) { }

        public override void StartSituation() { }

        public override void EndSituation() { }
        
        public override void OnPress() => m_button.SetSituation(new PressSituation(m_button));

        public override void OnRelease() { }
        
    }
}