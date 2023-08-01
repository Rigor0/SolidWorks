using TripleA.Core;
using TripleA.Runtime.Entity.Player.Controller;

namespace TripleA.Runtime.Entity.Player
{
    public abstract class PlayerBaseState
    {
        protected PlayerStateFactory _states;

        protected PlayerController _controller;
        public PlayerBaseState(PlayerController controller, PlayerStateFactory states)
        {
            _controller = controller;

            _states = states;
        }
        public abstract void EnterState();

        public abstract void UpdateState();

        public abstract void ExitState();

        public abstract void CheckSwitchState();

        public abstract void InitializeSubState();

        public abstract void SetStateAnimation();
        void UpdateStates() { }
        protected void SwitchState(PlayerBaseState newState) 
        {
            ExitState();

            newState.EnterState();

            _controller.CurrentState = newState;
        }

        protected void SetSuperState() { }
        protected void SetSubState() { }

        protected void RaiseInteractionAction()
        {
            EventManager.OnPlayerInteracted?.Invoke();
        }
    }
}
