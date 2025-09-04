using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class AdjustSpeedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movables;

        public AdjustSpeedSystem(GameContext game)
        {
            _movables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.Speed,
                    GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (GameEntity movable in _movables)
            {
                movable.ReplaceVelocity(movable.Velocity * movable.Speed);
            }
        }
    }
}