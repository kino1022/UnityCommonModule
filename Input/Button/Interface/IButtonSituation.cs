namespace UnityCommonModule.Input.Button.Interface {
    public interface IButtonSituation {

        public void OnPress();

        public void OnRelease();
        

        public void StartSituation();
        
        public void EndSituation();
    }
}