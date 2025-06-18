using System;
using System.Collections.Generic;
using ObservableCollections;
using R3;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction.Module {
    public class ObserveListModule : IReExecuteHandler , IDisposable {


        protected ICorrectionList list;
        
        public Action ReExecuteEvent { get; set; }
        
        protected CompositeDisposable disposables = new CompositeDisposable();
        
        
        public ObserveListModule(ICorrectionList list) {
            RegisterObserve(list);
        }

        public void Dispose() {
            disposables?.Dispose();
        }
    
        /// <summary>
        /// Observeの購読処理
        /// </summary>
        /// <param name="list"></param>
        protected virtual void RegisterObserve(ICorrectionList list) {
            list.List.ObserveAdd()
                .Subscribe(x => {
                    Debug.Log("補正値リストへの追加を観測しました");
                    OnCorrectionAdd(x);
                })
                .AddTo(disposables);
            
            list.List.ObserveRemove()
                .Subscribe(x => {
                    Debug.Log("補正値リストからの除外を観測しました");
                    OnCorrectionRemove(x);
                })
                .AddTo(disposables);
        }

        protected virtual void OnCorrectionAdd(CollectionAddEvent<ICorrection> x) {
            ReExecuteEvent?.Invoke();
        }

        protected virtual void OnCorrectionRemove(CollectionRemoveEvent<ICorrection> x) {
            ReExecuteEvent?.Invoke();
        }
    }
}