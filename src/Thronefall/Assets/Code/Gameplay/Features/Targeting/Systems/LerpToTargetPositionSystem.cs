using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Targeting
{
    public class LerpToTargetPositionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _entities;

        public LerpToTargetPositionSystem(GameContext game, ITimeService time)
        {
            _game = game;
            _time = time;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Target,
                    GameMatcher.WorldPosition,
                    GameMatcher.Speed,
                    GameMatcher.LerpToTargetPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity target = _game.GetEntityWithId(entity.Target);

                entity.ReplaceWorldPosition(Vector3.Lerp(entity.WorldPosition, target.WorldPosition, _time.DeltaTime * entity.Speed));
            }
        }
    }
}