using System.Collections.Generic;
using Entitas;

namespace Thronefall.Gameplay.Combat
{
    public class ProcessDamageWeaponHitSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _weaponHits;
        private readonly List<GameEntity> _buffer = new(64);

        public ProcessDamageWeaponHitSystem(GameContext game)
        {
            _game = game;
            _weaponHits = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WeaponHit,
                    GameMatcher.Target,
                    GameMatcher.Causer)
                .NoneOf(
                    GameMatcher.ProcessedHit));
        }

        public void Execute()
        {
            foreach (GameEntity weaponHit in _weaponHits.GetEntities(_buffer))
            {
                GameEntity target = _game.GetEntityWithId(weaponHit.Target);
                GameEntity weapon = _game.GetEntityWithId(weaponHit.Causer);

                target.ReplaceCurrentHp(target.CurrentHp - weapon.Damage.Value);
                
                if(target.hasTakeDamageAnimator)
                    target.TakeDamageAnimator.PlayTakeDamage();
                
                weaponHit.isProcessedHit = true;
            }
        }
    }
}