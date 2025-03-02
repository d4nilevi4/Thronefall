using System.Collections.Generic;
using Entitas;

namespace Thronefall.Gameplay.Combat
{
    public class WeaponDisableAttackReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public WeaponDisableAttackReactiveSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Attacking.Removed());

        protected override bool Filter(GameEntity attacker) => attacker.isAttacker && attacker.hasEquippedWeapon;

        protected override void Execute(List<GameEntity> attackers)
        {
            foreach (GameEntity attacker in attackers)
            {
                GameEntity weapon = _game.GetEntityWithId(attacker.EquippedWeapon);
                weapon.WeaponAnimator.SetIsAttacking(false);
            }
        }
    }
}