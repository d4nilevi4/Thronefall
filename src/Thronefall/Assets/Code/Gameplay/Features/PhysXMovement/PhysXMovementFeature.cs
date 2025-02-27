using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.PhysXMovement
{
    public sealed class PhysXMovementFeature : Feature
    {
        public PhysXMovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetVelocityByDirectionSystem>());
            
            Add(systemFactory.Create<SurfaceDetectionSystem>());
            Add(systemFactory.Create<AlignDirectionToSurfaceSystem>());
            Add(systemFactory.Create<AdjustSpeedSystem>());
            Add(systemFactory.Create<CheckGroundedSystem>());
            Add(systemFactory.Create<GravityImpactSystem>());
            
            Add(systemFactory.Create<AdjustVelocitySystem>());
            
            Add(systemFactory.Create<SynchronizePositionSystem>());
        }
    }
}