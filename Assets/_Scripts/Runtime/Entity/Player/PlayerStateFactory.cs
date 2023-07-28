using TripleA.Runtime.Entity.Player.Controller;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerStateFactory
    {
        PlayerController _context;

        public PlayerStateFactory(PlayerController currentContext)
        {
            _context = currentContext;
        }

        public PlayerIdleState Idle()
        {
            return new PlayerIdleState(_context, this);
        }

        public PlayerWalkState Walk()
        {
            return new PlayerWalkState(_context, this);
        }

        public PlayerRunState Run()
        {
            return new PlayerRunState(_context, this);
        }
    }
}
