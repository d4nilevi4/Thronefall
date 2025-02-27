using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class SynchronizePositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SynchronizePositionSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PhysXMovable,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceWorldPosition(entity.Rigidbody.position);
            }
        }
    }
}