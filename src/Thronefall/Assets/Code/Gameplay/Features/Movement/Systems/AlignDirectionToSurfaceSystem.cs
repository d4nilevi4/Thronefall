using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Movement
{
    public class AlignDirectionToSurfaceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AlignDirectionToSurfaceSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.SlideOnSurface,
                    GameMatcher.SurfaceNormal));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Vector3 projectedDirection = Vector3.ProjectOnPlane(entity.Direction, entity.SurfaceNormal).normalized;

                entity.ReplaceDirection(projectedDirection);
            }
        }
    }
}