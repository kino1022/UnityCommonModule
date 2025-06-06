namespace UnityCommonModule.InputControl.Button.Modules {
    public abstract class AHook : IHookPoint {
        
        protected AHook (AButtonBase button) {}
        
        public abstract void OnHook();
        
    }
}