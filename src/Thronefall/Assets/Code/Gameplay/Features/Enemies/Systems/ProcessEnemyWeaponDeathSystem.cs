using Entitas;

namespace Thronefall.Gameplay.Enemies
{
    public class ProcessEnemyWeaponDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly GameContext _game;

        public ProcessEnemyWeaponDeathSystem(GameContext game)
        {
            _game = game;
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
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