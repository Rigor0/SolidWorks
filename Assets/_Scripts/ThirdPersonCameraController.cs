using UnityEngine;
using TripleA.Core;

namespace CameraController.Core
{
    public class ThirdPersonCameraController : Singleton<ThirdPersonCameraController>
    {
        private Transform currentTransform;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            currentTransform = GetComponent<Transform>();
        }
        public Transform GetTransform()
        {
            return currentTransform;
        }
    }
}

