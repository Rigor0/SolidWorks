using UnityEngine;

namespace Camera.Core
{
    public class CameraController : MonoBehaviour
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

