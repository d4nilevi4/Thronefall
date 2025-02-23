using Entitas;
using Thronefall.Gameplay.Common;

namespace Thronefall.Gameplay.Movement
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;

        public DirectionalDeltaMoveSystem(GameContext contextParameter, ITimeService time)
        {
            _time = time;
            _movers = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.WorldPosition,
                    GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _movers)
            {
                entity.ReplaceWorldPosition(entity.WorldPosition + entity.Direction * entity.Speed * _time.DeltaTime);
            }
        }
    }
}