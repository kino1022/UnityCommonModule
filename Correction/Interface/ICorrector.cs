namespace UnityCommonModule.Correction.Interface {
    /// <summary>
    /// 補正値を管理するクラス対して適用するインターフェース
    /// </summary>
    public interface ICorrector {
        
        public IReExecuteHandler Handler { get; }

        public float Execute(float value);
        
        public void Add (ICorrection correction); 
        
        public void Remove (ICorrection correction);
    }
}