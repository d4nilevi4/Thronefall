using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Rotation
{
    public sealed class RotationFeature : CustomFeature
    {
        public RotationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RotationTowardsVelocitySystem>());
            Add(systemFactory.Create<RotateWeaponWhileAttackingSystem>());
        }
    }
}