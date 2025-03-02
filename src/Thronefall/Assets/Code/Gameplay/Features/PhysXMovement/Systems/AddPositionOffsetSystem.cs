using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class AddPositionOffsetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AddPositionOffsetSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PositionOffset));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceWorldPosition(entity.WorldPosition + entity.PositionOffset);
            }
        }
    }
}