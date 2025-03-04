using System.Collections.Generic;
using Entitas;

namespace Thronefall.Gameplay.HitDetection
{
    public class DestroyNotVerifiedWeaponHitsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _weaponHits;
        private readonly List<GameEntity> _buffer = new(64);

        public DestroyNotVerifiedWeaponHitsSystem(GameContext game)
        {
            _weaponHits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WeaponHit)
                .NoneOf(GameMatcher.VerifiedWeaponHit));
        }

        public void Cleanup()
        {
            foreach (GameEntity weaponHit in _weaponHits.GetEntities(_buffer))
            {
                weaponHit.Destroy();
            }
        }
    }
}