using Sirenix.OdinInspector;
using UnityCommonModule.PlayableAnimation.Interface;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace UnityCommonModule.PlayableAnimation.Graph
{
    public class GraphManager : SerializedMonoBehaviour, IOutputHolder, IGraphHolder
    {
        protected PlayableGraph m_graph;

        protected AnimationPlayableOutput m_output;
        /// <summary>
        /// 接続するAnimatorコンポーネント
        /// </summary>
        [SerializeField] private Animator m_animator;

        private void Awake()
        {
            SetUpPlayableGraph();
            SetUpPlayableOutput();
        }

        //------------------------Open methods-----------------------------------------

        public void StartGraph()
        {
            m_graph.Play();
        }

        public void StopGraph()
        {
            m_graph.Stop();
        }

        //------------------------interfaces methods-----------------------------------

        public PlayableGraph GetPlayableGraph()
        {
            return m_graph;
        }

        public AnimationPlayableOutput GetPlayableOutput()
        {
            return m_output;
        }

        //-------------------------SetUp methods--------------------------------------

        protected void SetUpPlayableGraph()
        {
            m_graph = PlayableGraph.Create("Animation Graph");
        }

        protected void SetUpPlayableOutput()
        {
            m_output = AnimationPlayableOutput.Create(m_graph, "Animation Output", m_animator);
        }
    }
}