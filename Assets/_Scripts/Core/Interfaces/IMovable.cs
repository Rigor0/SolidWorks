using UnityEngine;

namespace TripleA.Core.Interfaces
{
    public interface IMovable
    {
        float MoveSpeed { get; set; }
        void Movement(Transform transform, Vector3 direction);
    }
}

