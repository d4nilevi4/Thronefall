using Entitas;

namespace Thronefall.Gameplay.HitDetection
{
    public class ResetVerificationWeaponHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _weaponHits;

        public ResetVerificationWeaponHitSystem(GameContext game)
        {
            _weaponHits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WeaponHit));
        }

        public void Execute()
        {
            foreach (GameEntity weaponHit in _weaponHits)
            {
                weaponHit.isVerifiedWeaponHit = false;
            }
        }
    }
}