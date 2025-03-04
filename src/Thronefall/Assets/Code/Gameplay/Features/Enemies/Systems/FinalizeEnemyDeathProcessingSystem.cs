using System.Collections.Generic;
using Entitas;

namespace Thronefall.Gameplay.Enemies
{
    public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(32);

        public FinalizeEnemyDeathProcessingSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProcessingDeath = false;
            }
        }
    }
}