using TripleA.Runtime.Entity.Player.Controller;
using UnityEngine;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerController controller, PlayerStateFactory states) : base(controller, states)
        {
        }

        public override void CheckSwitchState()
        {
            if (_controller.PlayerRotation.MoveDir.magnitude > 0f)
            {
                SwitchState(_states.Walk());
            }

            if (_controller.PlayerInput.IsRunPressed)
            {
                SwitchState(_states.Run());
            }
        }

        public override void EnterState()
        {
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
            _controller.PlayerAnimation.MovementAnimation(_controller.Settings.defaultVelocity);
        }

        public override void UpdateState()
        {
            _controller.PlayerRotation.Rotate(_controller.PlayerInput.Horizontal, _controller.PlayerInput.Vertical, _controller.transform);

            if (_controller.PlayerInput.IsInteractPressed)
                _controller.PlayerInteraction.Interact();

            CheckSwitchState();
        }
    }
}
