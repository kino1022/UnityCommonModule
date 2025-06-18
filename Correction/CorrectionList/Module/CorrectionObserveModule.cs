using System;
using ObservableCollections;
using R3;
using UnityCommonModule.Correction.Interface;
using UnityEngine;

namespace UnityCommonModule.Correction.Module {
    /// <summary>
    /// 補正値リストの各種変化を検知して適切なイベントを発火するイベント
    /// </summary>
    public class CorrectionObserveModule : IDisposable , ICorrectionDisposeHandler , IReExecuteHandler {
        
        public Action<ICorrection> DisposeEvent { get; set; }

        public Action ReExecuteEvent { get; set; }
        
        protected CompositeDisposable disposables = new CompositeDisposable();

        public CorrectionObserveModule(IReadOnlyObservableList<ICorrection> corrections) {
            RegisterObserveList(corrections);
        }
        
        public void Dispose() {
            disposables?.Dispose();
        }

        protected void RegisterObserveList(IReadOnlyObservableList<ICorrection> list) {
            list.ObserveAdd()
                .Subscribe(x => {
                    Debug.Log("リストへの補正値の追加を検知しました");
                    OnCorrectionAdded(x);
                })
                .AddTo(disposables);
        }

        protected virtual void RegisterObserveCorrection(ICorrection correction) {
            Observable
                .EveryValueChanged(correction, x => x.IsActive == false)
                .Subscribe(x => {
                    DisposeEvent?.Invoke(correction);
                })
                .AddTo(disposables);
            
            Observable
                .EveryValueChanged(correction, x => x.Value)
                .Subscribe( x => {
                    ReExecuteEvent?.Invoke();
                })
                .AddTo(disposables);
        }


        protected virtual void OnCorrectionAdded(CollectionAddEvent<ICorrection> x) {
            RegisterObserveCorrection(x.Value);
        }
    }
}