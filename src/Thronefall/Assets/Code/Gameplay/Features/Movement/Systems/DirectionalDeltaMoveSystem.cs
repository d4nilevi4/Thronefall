using Entitas;

namespace Thronefall.Gameplay.Movement
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movables;

        public DirectionalDeltaMoveSystem(GameContext contextParameter, ITimeService time)
        {
            _time = time;
            _movables = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.Speed,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity movable in _movables)
            {
                movable.ReplaceWorldPosition(movable.WorldPosition + movable.Direction * movable.Speed * _time.DeltaTime);
            }
        }
    }
}