using System;
using UnityCommonModule.Correction;

namespace UnityCommonModule.Status.Interface {
    /// <summary>
    /// 補正できるステータスに対して適応するインターフェース
    /// </summary>
    public interface ICorrectable  {

        public void ExecuteCorrection();
        
        public void AddCorrection(ACorrection correction);
        
        public void RemoveCorrection(ACorrection correction);
        
    }
}