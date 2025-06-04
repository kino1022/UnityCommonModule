namespace UnityCommonModule.Correction.Strategy.Interface {
    public interface ICalculateStrategy {
        
        public float ApplyCorrection(float value);

        public float CalculateTotalValue();
        
    }
}