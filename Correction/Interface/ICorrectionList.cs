using System.Collections.Generic;
using ObservableCollections;

namespace UnityCommonModule.Correction.Interface {
    public interface ICorrectionList : IReExecuteHandler {
        
        public ICorrectionType Type { get; }
        
        public IReadOnlyObservableList<ICorrection> List { get; }

        public void Add(ICorrection correction);
        
        public void Remove(ICorrection correction);

        public float Calculate(float value);
    }
}