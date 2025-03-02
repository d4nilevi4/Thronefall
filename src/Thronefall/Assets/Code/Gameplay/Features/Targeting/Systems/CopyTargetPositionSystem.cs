using Entitas;

namespace Thronefall.Gameplay.Targeting
{
    public class CopyTargetPositionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _entities;

        public CopyTargetPositionSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Target,
                    GameMatcher.CopyTargetPosition,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity target = _game.GetEntityWithId(entity.Target);

                entity.ReplaceWorldPosition(target.WorldPosition);
            }
        }
    }
}