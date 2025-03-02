using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class SyncWorldPosition2TransformSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SyncWorldPosition2TransformSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform,
                    GameMatcher.SyncTransformPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.Transform.position = entity.WorldPosition;
            }
        }
    }
}