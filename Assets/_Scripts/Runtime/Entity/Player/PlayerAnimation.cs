using TripleA.Core.Interfaces;
using UnityEngine;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerAnimation : IAnimatable
    {
        Animator m_animator;
        public Animator Animator => m_animator;

        int m_velocityHash;

        public PlayerAnimation(Animator animator)
        {
            m_velocityHash = Animator.StringToHash("Velocity");

            m_animator = animator;
        }


        public void MovementAnimation(float velocity)
        {
            m_animator.SetFloat(m_velocityHash, velocity);            
        }
    }
}
