using System;
using UnityCommonModule.Input.Button.Definition;

namespace UnityCommonModule.Input.Button.Interface {
    public interface IChangeSituationHandler {
        public Action<ButtonSituation> SituationChangeEvent { get; set; }
    }
}