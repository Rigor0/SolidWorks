using UnityEngine;

namespace TripleA.Core.Interfaces
{
    public interface IRotatable
    {
        Vector3 MoveDir { get; set; }
        void Rotate(float horizontal, float vertical, Transform transform);

    }
}
