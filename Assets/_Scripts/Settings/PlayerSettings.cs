using System;
using UnityEngine;

namespace _Scripts.Settings.PlayerSettings
{
    [Serializable]
    public class PlayerSettings
    {
        [Range(0f, 10f)]
        public float speed;

        [Range(0f, 10f)]
        public float runSpeed;

        [Range(0f, 1f)]
        public float defaultVelocity;

        [Range(0f, 1f)]
        public float walkVelocity;

        [Range(0f, 1f)]
        public float runVelocity;

        [Range(0f, 0.5f)]
        public float smoothRotationTime;

        [Range(0f, 5f)]
        public float turnSmoothVelocity;
    }
}

