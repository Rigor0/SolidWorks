using UnityEngine;
using TripleA.Core;

namespace Camera.Core
{
    public class ThirdPersonCameraController : Singleton<ThirdPersonCameraController>
    {
        private Transform currentTransform;

        private void Start()
        {
            currentTransform = GetComponent<Transform>();
        }
        public Transform GetTransform()
        {
            return currentTransform;
        }
    }
}

