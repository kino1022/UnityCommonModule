using UnityCommonModule.Input.Button.Interface;

namespace UnityCommonModule.Input.Button.Situation {
    public class HoldSituation : AButtonSituation{
        
        public HoldSituation(IButtonInstance button) : base(button) { }

        public override void StartSituation() {
            throw new System.NotImplementedException();
        }

        public override void EndSituation() {
            throw new System.NotImplementedException();
        }

        public override void OnPress() {
            throw new System.NotImplementedException();
        }

        public override void OnRelease() {
            throw new System.NotImplementedException();
        }
    }
}