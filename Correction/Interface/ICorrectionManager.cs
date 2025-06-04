using System;

namespace UnityCommonModule.Correction.Interface {
    
    public interface ICorrectionManager {
        
        public float ExecuteCorrection(float value);
        
        public void AddCorrection(ACorrection correction);
        
        public void RemoveCorrection(ACorrection target);
    }
    
}