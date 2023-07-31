using UnityEngine;
using _Scripts.Settings.PlayerSettings;
using TripleA.Core.Interfaces;
using Camera.Core;


namespace TripleA.Runtime.Entity.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerSettings _settings;
        public PlayerSettings Settings => _settings;

        [SerializeField] ThirdPersonCameraController _cam;
        public ThirdPersonCameraController Cam => _cam;

        PlayerBaseState _currentState;

        public PlayerBaseState CurrentState 
        { 
            get 
            {
                return _currentState; 
            } 
            set 
            { 
                _currentState = value; 
            } 
        }

        PlayerStateFactory _states;

        IMovable playerMovement;
        public IMovable PlayerMovement => playerMovement;

        PlayerInput playerInput;

        public PlayerInput PlayerInput => playerInput;

        IRotatable playerRotation;

        public IRotatable PlayerRotation => playerRotation;

        PlayerAnimation playerAnimation;
        public PlayerAnimation PlayerAnimation => playerAnimation;

        void Awake()
        {
            InitClasses();
            InitStartState();
        }

        void Update()
        {
            _currentState.UpdateState();
        }

        void InitClasses()
        {
            playerInput = new PlayerInput();
            playerRotation = new PlayerRotation(Settings.turnSmoothVelocity, Settings.smoothRotationTime, Cam);
            playerMovement = new PlayerMovement(GetComponent<CharacterController>());
            playerAnimation = new PlayerAnimation(GetComponent<Animator>());
        }

        void InitStartState()
        {
            _states = new PlayerStateFactory(this);

            _currentState = _states.Idle();
            _currentState.EnterState();
        }
    }
}
