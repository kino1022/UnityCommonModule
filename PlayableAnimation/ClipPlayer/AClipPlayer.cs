using UnityCommonModule.PlayableAnimation.Interface;
using UnityEngine;
using UnityEngine.Animations;

namespace UnityCommonModule.PlayableAnimation.ClipPlayer {
    public abstract class AClipPlayer<T> : ScriptableObject {
        protected IGraphHolder m_graph;
        protected IOutputHolder m_output;
    }
}