using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Rotation
{
    public sealed class RotationFeature : Feature
    {
        public RotationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RotationTowardsVelocitySystem>());
        }
    }
}