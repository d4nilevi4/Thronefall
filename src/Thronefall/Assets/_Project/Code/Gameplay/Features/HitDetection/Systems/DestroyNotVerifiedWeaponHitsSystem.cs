using System.Collections.Generic;
using Entitas;
using Thronefall.Common;

namespace Thronefall.Gameplay.HitDetection
{
    public class DestroyNotVerifiedWeaponHitsSystem : IFixedExecuteSystem
    {
        private readonly IGroup<GameEntity> _weaponHits;
        private readonly List<GameEntity> _buffer = new(64);

        public DestroyNotVerifiedWeaponHitsSystem(GameContext game)
        {
            _weaponHits = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WeaponHit)
                .NoneOf(GameMatcher.VerifiedWeaponHit));
        }

        public void FixedExecute()
        {
            foreach (GameEntity weaponHit in _weaponHits.GetEntities(_buffer))
            {
                weaponHit.Destroy();
            }
        }
    }
}