using System;
using UnityEngine;

namespace UnityCommonModule.Input.Leber.Definition {
    public readonly struct Direction {
        
        public readonly static DirectionEight Eight = new DirectionEight();
        
        public readonly static DirectionFour Four = new DirectionFour();

        
        public override bool Equals(object obj) => obj is Direction other && Equals(other);

        public static bool operator ==(Direction x, Direction y) => x.Equals(y);
        
        public static bool operator !=(Direction x, Direction y) => !x.Equals(y);
    }
    
}