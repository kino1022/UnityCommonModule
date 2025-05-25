using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityCommonModule.PlayableAnimation.Interface;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace UnityCommonModule.PlayableAnimation.ClipPlayer {
    [Serializable]
    public class AnimationClipPlayer {
        
        protected IGraphHolder m_graph;

        protected IOutputHolder m_output;

        protected AnimationClip m_clip;

        protected AnimationClipPlayable m_playable;
        
        //-----------------------open methods-------------------------------
        
        [Button("Start Animation")]
        public void StartAnimation() {
            m_playable.Play();
        }
        [Button("Stop Animation")]
        public void StopAnimation() {
            m_playable.Pause();
        }

        //-----------------------SetUp methods------------------------------

        protected AnimationClipPlayable CreateClipPlayable() {
            return AnimationClipPlayable.Create(m_graph.GetPlayableGraph(), m_clip);
        }

        //-----------------------Connect methods-----------------------------

        protected void ConnectOutput() {
            m_output.GetPlayableOutput().SetSourcePlayable(m_playable);
        }
    }
}