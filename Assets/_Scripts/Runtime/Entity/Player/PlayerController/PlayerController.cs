using UnityEngine;
using _Scripts.Settings.PlayerSettings;
using TripleA.Core.Interfaces;
using CameraController.Core;
using UnityEngine.Animations.Rigging;


namespace TripleA.Runtime.Entity.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rig m_aimRig;

        [SerializeField] PlayerSettings m_settings;
        public PlayerSettings Settings => m_settings;

        [SerializeField] ThirdPersonCameraController m_cam;
        public ThirdPersonCameraController Cam => m_cam;

        PlayerBaseState m_currentState;

        public PlayerBaseState CurrentState 
        { 
            get 
            {
                return m_currentState; 
            } 
            set 
            { 
                m_currentState = value; 
            } 
        }

        PlayerStateFactory m_states;

        IMovable m_playerMovement;
        public IMovable PlayerMovement => m_playerMovement;

        PlayerInput m_playerInput;

        public PlayerInput PlayerInput => m_playerInput;

        IRotatable m_playerRotation;

        public IRotatable PlayerRotation => m_playerRotation;

        PlayerAnimation m_playerAnimation;
        public PlayerAnimation PlayerAnimation => m_playerAnimation;

        PlayerInteraction m_playerInteraction;
        public PlayerInteraction PlayerInteraction => m_playerInteraction;

        void Awake()
        {
            InitClasses();
            InitStartState();
        }

        void Update()
        {
            m_currentState.UpdateState();
        }

        void InitClasses()
        {
            m_playerInput = new PlayerInput();
            m_playerRotation = new PlayerRotation(Settings.turnSmoothVelocity, Settings.smoothRotationTime, Cam);
            m_playerMovement = new PlayerMovement(GetComponent<CharacterController>());
            m_playerAnimation = new PlayerAnimation(GetComponent<Animator>());
            m_playerInteraction = GetComponent<PlayerInteraction>();
        }

        void InitStartState()
        {
            m_states = new PlayerStateFactory(this);

            m_currentState = m_states.Idle();
            m_currentState.EnterState();
        }
    }
}
