using Thronefall.Common;
using Thronefall.Common.Entity;

namespace Thronefall.Gameplay.HitDetection
{
    public class HitFactory : IHitFactory
    {
        public GameEntity CreateWeaponHit(int weaponId, int targetId)
        {
            return CreateEntity.Empty()
                .AddTarget(targetId)
                .AddCauser(weaponId)
                .With(x => x.isWeaponHit = true)
                .With(x => x.isVerifiedWeaponHit = true);
        }
    }
}