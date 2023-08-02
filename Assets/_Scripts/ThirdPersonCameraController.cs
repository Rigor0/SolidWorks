using UnityEngine;
using Cinemachine;
using TripleA.Core;
using System;

namespace CameraController.Core
{
    public class ThirdPersonCameraController : MonoBehaviour
    {
        private Transform m_currentTransform;

        [SerializeField] CinemachineVirtualCamera m_aimCamera;

        void Start()
        {
            m_currentTransform = GetComponent<Transform>();
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnEnable()
        {
            EventManager.OnPlayerAimed += OnPlayerAimedHandler;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerAimed -= OnPlayerAimedHandler;
        }

        void OnPlayerAimedHandler(bool isAiming)
        {
            SetAim(isAiming);
        }

        void SetAim(bool isAiming)
        {
            if (isAiming)
                m_aimCamera.Priority = 11;
            else
                m_aimCamera.Priority = 9;
        }

        public Transform GetTransform()
        {
            return m_currentTransform;
        }
    }
}

