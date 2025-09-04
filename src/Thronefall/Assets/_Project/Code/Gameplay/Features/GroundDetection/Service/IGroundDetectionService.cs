using UnityEngine;

namespace Thronefall.Gameplay.GroundDetection
{
    public interface IGroundDetectionService
    {
        bool TryGetRaycastResult(Vector3 origin, out RaycastHit raycastHit);
    }
}