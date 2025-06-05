using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityCommonModule.Correction.Always;

namespace UnityCommonModule.Status.Data;
/// <summary>
/// ステータスを初期化する際に参照するクラス
/// </summary>
public class StatusInitializeData<T> : SerializedScriptableObject {
    
    [LabelText("初期値")]
    protected T m_entryValue;
    
    [LabelText("初期補正値")] 
    protected List<AlwaysCorrection> m_initialCorrections = new List<AlwaysCorrection>();
    
    
}