using System;
using UnityCommonModule.PlayableAnimation.ClipPlayer;
using UnityEngine;

namespace UnityCommonModule.PlayableAnimation.ClipPlayer {
    [Serializable]
    public class AnimationInput {
        
        public AnimationClipPlayer player;
        public float mixerWeight;

        public AnimationInput(AnimationClipPlayer player, float mixerWeight) {
            this.player = player;
            this.mixerWeight = mixerWeight;
        }
    }
}