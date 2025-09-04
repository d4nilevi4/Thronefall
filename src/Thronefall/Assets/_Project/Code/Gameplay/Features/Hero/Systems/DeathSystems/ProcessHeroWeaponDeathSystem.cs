using Entitas;

namespace Thronefall.Gameplay.Hero
{
    public class ProcessHeroWeaponDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly GameContext _game;

        public ProcessHeroWeaponDeathSystem(GameContext game)
        {
            _game = game;
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath,
                    GameMatcher.EquippedWeapon));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                GameEntity weapon = _game.GetEntityWithId(enemy.EquippedWeapon);
                weapon.isDestructed = true;
            }
        }
    }
}