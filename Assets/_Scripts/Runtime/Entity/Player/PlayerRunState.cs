using TripleA.Runtime.Entity.Player.Controller;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerRunState : PlayerBaseState
    {
        public PlayerRunState(PlayerController controller, PlayerStateFactory states) : base(controller, states)
        {
        }

        public override void CheckSwitchState()
        {
            if (!_controller.PlayerInput.IsRunPressed)
            {
                SwitchState(_states.Walk());
            }

            if (_controller.PlayerRotation.MoveDir.magnitude < 0.05)
            {
                SwitchState(_states.Idle());
            }
        }

        public override void EnterState()
        {
            _controller.PlayerMovement.MoveSpeed = _controller.Settings.runSpeed;

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
            _controller.PlayerAnimation.MovementAnimation(_controller.Settings.runVelocity);
        }

        public override void UpdateState()
        {
            _controller.PlayerRotation.Rotate(_controller.PlayerInput.Horizontal, _controller.PlayerInput.Vertical, _controller.transform);
            _controller.PlayerMovement.Movement(_controller.transform, _controller.PlayerRotation.MoveDir);

            if(_controller.PlayerInput.IsInteractPressed)
                _controller.PlayerInteraction.Interact();

            SetAim();

            CheckSwitchState();
        }

        
    }
}
