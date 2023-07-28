using UnityEngine;
using TripleA.Core.Interfaces;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerMovement : IMovable
    {
        CharacterController _controller;
        public float MoveSpeed { get ; set; }
        public PlayerMovement(CharacterController ctrl)
        {
            _controller = ctrl;
        }
        public void Movement(Transform transform, Vector3 direction)
        {
            _controller.Move(direction * MoveSpeed * Time.deltaTime);
        }
    }

}
