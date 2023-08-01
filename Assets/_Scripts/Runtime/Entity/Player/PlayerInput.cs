using UnityEngine;
using TripleA.Core.Interfaces;

namespace TripleA.Runtime.Entity.Player
{
    public class PlayerInput : IInput
    {
        static readonly string horizontal = "Horizontal";

        static readonly string vertical = "Vertical";
        public bool IsRunPressed => Input.GetKey(KeyCode.LeftShift);
        public float Horizontal => Input.GetAxisRaw(horizontal);
        public float Vertical => Input.GetAxisRaw(vertical);
        public bool IsInteractPressed => Input.GetKeyDown(KeyCode.E);
    }

}
