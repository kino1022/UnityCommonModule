using System;
using System.Collections.Generic;
using UnityCommonModule.PlayableAnimation.Interface;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace UnityCommonModule.PlayableAnimation.ClipPlayer
{
    [Serializable]
    public class AniamtionClipPlayer
    {
        protected IGraphHolder m_graph;

        protected IOutputHolder m_output;

        protected AnimationClip m_clip;

        protected AnimationClipPlayable m_playable;

        protected List<PlayableBehaviour> m_behaviours;


        //-----------------------SetUp methods------------------------------

        protected AnimationClipPlayable CreateClipPlayable()
        {
            return AnimationClipPlayable.Create(m_graph.GetPlayableGraph(), m_clip);
        }

        //-----------------------Connect methods-----------------------------

        protected void ConnectOutput()
        {
            
        }
    }
}