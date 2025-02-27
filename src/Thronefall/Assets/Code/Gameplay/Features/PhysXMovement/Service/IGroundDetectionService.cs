using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public interface IGroundDetectionService
    {
        bool TryGetSurfaceNormal(Vector3 origin, out Vector3 normal);

        bool IsGrounded(Vector3 origin);
    }
}