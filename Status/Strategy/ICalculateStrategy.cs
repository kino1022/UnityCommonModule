using System;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Status.Correctable;

namespace UnityCommonModule.Status.Strategy {
    public interface ICalculateStrategy<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> {
        
        public void Increase(T amount,ref RawStatusValue<T> raw);
        
        public void Decrease(T amount,ref RawStatusValue<T> raw);
        
        public void ApplyCorrection(ref RawStatusValue<T> raw,ref CorrectedStatusValue<T> corrected ,ref ICorrectionManager correction);
    }
}