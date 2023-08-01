using CameraController.Core;
using UnityEngine;
using TripleA.Core.Interfaces;


namespace TripleA.Runtime.Entity.Player
{
    public class PlayerRotation : IRotatable
    {
        private ThirdPersonCameraController _camController;

        float _rotationSmoothVelocity;

        float _rotationSmoothTime;

        public Vector3 MoveDir { get ; set ; }

        public PlayerRotation(float rotationSmoothVelocity, float rotationSmoothTime, ThirdPersonCameraController camController)
        {
            _rotationSmoothVelocity = rotationSmoothVelocity;

            _rotationSmoothTime = rotationSmoothTime;

            _camController = camController;
            
        }
        public void Rotate(float horizontal, float vertical, Transform transform)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camController.GetTransform().eulerAngles.y;

                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _rotationSmoothVelocity, _rotationSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            }

            else
                MoveDir = Vector3.zero;

        }
    }
}
