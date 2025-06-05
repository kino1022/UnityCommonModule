using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityCommonModule.Correction.Definition;
using UnityCommonModule.Correction.Interface;

namespace UnityCommonModule.Correction.Instant.Asset;

[Serializable]
public class CountLimitCorrection : InstantCorrection {
    
    [OdinSerialize] private int _limit;

    protected int m_limit {
        get { return _limit; }
        set {
            _limit = value;
            OnPostCountChange();
        }
    }

    public CountLimitCorrection(int limit, float value, CorrectionType type, List<ICorrectionDisposeHandler> handlers) 
        : base(value, type, handlers) {
        _limit = limit;
    }
    
    public CountLimitCorrection(int limit, float value, CorrectionType type) 
        : base(value, type) {
        _limit = limit;
    }

    protected override void OnUsed() {
        m_limit--;
    }

    protected virtual void OnPostCountChange() {
        if (m_limit <= 0.0f) {
            OnDisposeEvent();
            return;
        }
    }
}