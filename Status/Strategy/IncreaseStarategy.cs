using UnityCommonModule.Status.Interface;

namespace UnityCommonModule.Script.UnityCommonModule.Status.Strategy {
    public class IncreaseStrategy : IStrategy<float> {
        
        private float _value;

        public IncreaseStrategy(float value) {
            _value = value;
        }

        public float Apply(float originvalue) {
            originvalue += _value;
        }
    }
}