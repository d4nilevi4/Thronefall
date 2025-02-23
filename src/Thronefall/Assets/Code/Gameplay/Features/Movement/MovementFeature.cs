using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SurfaceDetectionSystem>());
            Add(systemFactory.Create<AlignDirectionToSurfaceSystem>());
            Add(systemFactory.Create<DirectionalDeltaMoveSystem>());
            
            Add(systemFactory.Create<UpdateTransformPositionSystem>());
        }
    }
}