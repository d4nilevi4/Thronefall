using Entitas;
using Thronefall.Common;

namespace Thronefall.Gameplay.HitDetection
{
    public class ResetVerificationWeaponHitSystem : IFixedExecuteSystem
    {
        private readonly IGroup<GameEntity> _weaponHits;

        public ResetVerificationWeaponHitSystem(GameContext game)
        {
            _weaponHits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WeaponHit));
        }

        public void FixedExecute()
        {
            foreach (GameEntity weaponHit in _weaponHits)
            {
                weaponHit.isVerifiedWeaponHit = false;
            }
        }
    }
}