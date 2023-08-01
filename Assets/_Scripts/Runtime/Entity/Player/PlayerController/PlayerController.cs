using UnityEngine;
using _Scripts.Settings.PlayerSettings;
using TripleA.Core.Interfaces;
using CameraController.Core;


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

        IMovable _playerMovement;
        public IMovable PlayerMovement => _playerMovement;

        PlayerInput _playerInput;

        public PlayerInput PlayerInput => _playerInput;

        IRotatable _playerRotation;

        public IRotatable PlayerRotation => _playerRotation;

        PlayerAnimation _playerAnimation;
        public PlayerAnimation PlayerAnimation => _playerAnimation;

        PlayerInteraction _playerInteraction;
        public PlayerInteraction PlayerInteraction => _playerInteraction;

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
            _playerInput = new PlayerInput();
            _playerRotation = new PlayerRotation(Settings.turnSmoothVelocity, Settings.smoothRotationTime, Cam);
            _playerMovement = new PlayerMovement(GetComponent<CharacterController>());
            _playerAnimation = new PlayerAnimation(GetComponent<Animator>());
            _playerInteraction = GetComponent<PlayerInteraction>();
        }

        void InitStartState()
        {
            _states = new PlayerStateFactory(this);

            _currentState = _states.Idle();
            _currentState.EnterState();
        }
    }
}
