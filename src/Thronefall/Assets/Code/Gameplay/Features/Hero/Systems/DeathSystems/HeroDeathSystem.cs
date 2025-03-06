using Entitas;

namespace Thronefall.Gameplay.Hero
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public HeroDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isRotateTowardsVelocity = false;

                enemy.isDestructed = true;
            }
        }
    }
}