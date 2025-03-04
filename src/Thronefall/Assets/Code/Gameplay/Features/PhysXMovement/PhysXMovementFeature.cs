using Thronefall.Common;
using Thronefall.Gameplay.GroundDetection;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.PhysXMovement
{
    public sealed class PhysXMovementFeature : CustomFeature
    {
        public PhysXMovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<GroundDetectionFeature>());
            
            Add(systemFactory.Create<SetVelocityByDirectionSystem>());
            
            Add(systemFactory.Create<SurfaceDetectionSystem>());
            Add(systemFactory.Create<AlignDirectionToSurfaceSystem>());
            Add(systemFactory.Create<AdjustSpeedSystem>());
            Add(systemFactory.Create<GravityImpactSystem>());
            
            Add(systemFactory.Create<AdjustVelocitySystem>());
            
            Add(systemFactory.Create<SyncTransform2WorldPositionSystem>());
            Add(systemFactory.Create<SyncWorldPosition2TransformSystem>());
            
            Add(systemFactory.Create<PhysXDrawGizmoFeature>());
        }
    }
}