using UnityEngine;

namespace Game
{
    public interface IMovementDirectionSource
    {
        Vector3 MovementDirection { get; }
    }
}
