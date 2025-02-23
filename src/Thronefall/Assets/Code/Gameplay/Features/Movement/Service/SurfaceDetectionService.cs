using UnityEngine;

namespace Thronefall.Gameplay.Movement
{
    public class SurfaceDetectionService : ISurfaceDetectionService
    {
        private const float RAY_OFFSET = .1f;
        
        public bool TryGetSurfaceNormal(Vector3 origin, out Vector3 normal)
        {
            origin.y += RAY_OFFSET;

            if (Physics.Raycast(origin, Vector3.down, out var hit, RAY_OFFSET * 2))
            {
                normal = hit.normal;
                return true;
            }

            normal = Vector3.zero;
            return false;
        }
    }
}