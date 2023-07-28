using TripleA.Runtime.Entity.Player.Controller;
using UnityEngine;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerWalkState : PlayerBaseState
    {
        public PlayerWalkState(PlayerController controller, PlayerStateFactory states) : base(controller, states)
        {
        }

        public override void CheckSwitchState()
        {
            if (_controller.PlayerRotation.MoveDir.magnitude < 0.05)
            {
                SwitchState(_states.Idle());
            }

            if (_controller.PlayerInput.IsRunPressed)
            {
                SwitchState(_states.Run());
            }
        }

        public override void EnterState()
        {
            _controller.PlayerMovement.MoveSpeed = _controller.Settings.speed;

            SetStateAnimation();
        }

        public override void ExitState()
        {
        }

        public override void InitializeSubState()
        {
        }

        public override void SetStateAnimation()
        {
            _controller.PlayerAnimation.MovementAnimation(_controller.Settings.walkVelocity);
        }

        public override void UpdateState()
        {
            _controller.PlayerRotation.Rotate(_controller.PlayerInput.Horizontal, _controller.PlayerInput.Vertical, _controller.transform);
            _controller.PlayerMovement.Movement(_controller.transform, _controller.PlayerRotation.MoveDir);

            CheckSwitchState();
        }
    }
}
