using Entitas;

namespace Thronefall.Gameplay.Movement
{
    public class UpdateTransformPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movables;

        public UpdateTransformPositionSystem(GameContext game)
        {
            _movables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity movable in _movables)
            {
                movable.Transform.position = movable.WorldPosition;
            }
        }
    }
}