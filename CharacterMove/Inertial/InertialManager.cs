using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityCommonModule.CharacterMove.Interface;

namespace UnityCommonModule.CharacterMove.Inertial {
    public class InertialManager : AMovementManager  {
        
        [SerializeField] protected List<Inertial> m_inertials;
        
        //-----------------API methods------------------------------

        public override Vector3 GetMovement() {
            return CalculateMovement();
        }

        public void AddInertial(Inertial inertial) {
            m_inertials.Add(inertial);
            AddListenerDispose(inertial);
        }
        
        //-----------------Listener methods-------------------------

        protected void AddListenerDispose(Inertial inertial) {
            inertial.DisposeEvent += OnDisposeInertial;
        }

        protected void RemoveListenerDispose(Inertial inertial) {
            inertial.DisposeEvent -= OnDisposeInertial;
        }
        
        //-----------------Hook point--------------------------------

        protected void OnDisposeInertial(Inertial inertial) {
            m_inertials.Remove(inertial);
            RemoveListenerDispose(inertial);
        }

        //-----------------logic methods-----------------------------

        protected Vector3 CalculateMovement() {
            var result = Vector3.zero;
            foreach (var inertial in m_inertials) {
                result += inertial.GetMovement();
            }
            return result;
        }
    }
}