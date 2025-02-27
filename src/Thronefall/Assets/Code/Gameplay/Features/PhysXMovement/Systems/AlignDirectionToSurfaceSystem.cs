using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class AlignDirectionToSurfaceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AlignDirectionToSurfaceSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.SlideOnSurface,
                    GameMatcher.SurfaceNormal,
                    GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Vector3 projectedDirection = Vector3.ProjectOnPlane(entity.Velocity, entity.SurfaceNormal).normalized;

                entity.ReplaceVelocity(projectedDirection);
            }
        }
    }
}