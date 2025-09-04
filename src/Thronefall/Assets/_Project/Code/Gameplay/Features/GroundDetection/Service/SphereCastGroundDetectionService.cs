using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.GroundDetection
{
    public class SphereCastGroundDetectionService : IGroundDetectionService
    {
        private readonly float _sphereRadius = .2f;
        private readonly Vector3 _sphereOffset = new (0, .2f, 0);
        private readonly float _maxDistanceCast = .05f;

        private readonly RaycastHit[] _hitResults = new RaycastHit[1];
        
        public bool TryGetRaycastResult(Vector3 origin, out RaycastHit raycastHit)
        {
            int hitCount = Physics.SphereCastNonAlloc(
                origin: origin + _sphereOffset, 
                radius: _sphereRadius, 
                direction: Vector3.down, 
                results: _hitResults,
                maxDistance: _maxDistanceCast,
                layerMask: CollisionLayer.Ground.AsMask());
            
            if (hitCount == 0)
            {
                raycastHit = default;
                return false;
            }

            raycastHit = _hitResults[0];
            return true;
        }
    }
}