namespace UnityCommonModule.Correction.Strategy.Interface {
    public interface ICalculateStrategy<C> where C : ACorrection {
        
        public float ApplyCorrection(float value);

        public float CalculateTotalValue();
        
    }
}