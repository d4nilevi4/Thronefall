using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.HitDetection
{
    public sealed class HitDetectionFeature : CustomFeature
    {
        public HitDetectionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ResetVerificationWeaponHitSystem>());
            Add(systemFactory.Create<WeaponSphereBladeHitDetectionSystem>());
            
            Add(systemFactory.Create<DestroyNotVerifiedWeaponHitsSystem>());

            AddDrawGizmoFeatures(systemFactory);
        }

        private void AddDrawGizmoFeatures(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DrawWeaponSphereBladeGizmoSystem>());
        }
    }
}