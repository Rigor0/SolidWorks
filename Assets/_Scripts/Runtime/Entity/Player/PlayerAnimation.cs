using TripleA.Core.Interfaces;
using UnityEngine;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerAnimation : IAnimatable
    {
        Animator _animator;
        public Animator Animator => _animator;

        int _velocityHash;

        public PlayerAnimation(Animator animator)
        {
            _velocityHash = Animator.StringToHash("Velocity");

            _animator = animator;
        }


        public void MovementAnimation(float velocity)
        {
            _animator.SetFloat(_velocityHash, velocity);            
        }
    }
}
