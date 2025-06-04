using System;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Always.Interface {
    public interface IAlwaysCorrectionManager : ICorrectionManager , IRequireReExecuteHandler {
    }
}