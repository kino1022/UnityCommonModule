using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityCommonModule.Correction.CorrectionType;
using UnityCommonModule.Correction.Interface;
using UnityCommonModule.Correction.Module;
using UnityEngine;

namespace UnityCommonModule.Correction {
    [Serializable]
    public class CorrectionManager : ICorrector {
        [OdinSerialize, LabelText("補正値管理リストのインスタンス")]
        protected List<ICorrectionList> m_list = new List<ICorrectionList>() {
            new CorrectionList(new FixedType()),
            new CorrectionList(new RatioType()),
        };
        [OdinSerialize, LabelText("補正値計算の際の計算順")]
        protected List<ICorrectionType> m_priority = new List<ICorrectionType>() {
            new FixedType(),
            new RatioType()
        };

        protected List<IReExecuteHandler> m_handlers = new List<IReExecuteHandler>();

        protected ReExecuteHandleModule m_handle = new ReExecuteHandleModule();

        public IReExecuteHandler Handler => m_handle;

        public CorrectionManager() {

            foreach(var list in m_list) {
                m_handlers.Add(new ObserveListModule(list));
            }

            foreach(var handler in m_handlers) {
                AddModuleHandler(handler);
            }

        }

        public void Add(ICorrection correction) {
            var target = m_list.Find(x => x.Type.GetType() == correction.Type.GetType());

            if(target == null) {
                UnityEngine.Debug.Log($"{correction.GetType()}に対応した補正値管理リストが見つかりませんでした");
                return;
            }

            target.Add(correction);
        }

        public void Remove(ICorrection correction) {
            var target = m_list.Find(x => x.Type.GetType() == correction.Type.GetType());

            if(target == null) {
                return;
            }

            target.Remove(correction);
        }

        public float Execute(float value) {
            var result = value;

            foreach(var type in m_priority) {
                var list = m_list.Find(x => x.Type.GetType() == type.GetType());

                if(list == null) {
                    continue;
                }

                result = list.Calculate(result);
            }

            foreach(var list in m_list) {
                list.OnExecuted();
            }

            return result;
        }

        protected void AddModuleHandler(IReExecuteHandler handler) {
            m_handle.AddModule(handler);
        }
    }
}
