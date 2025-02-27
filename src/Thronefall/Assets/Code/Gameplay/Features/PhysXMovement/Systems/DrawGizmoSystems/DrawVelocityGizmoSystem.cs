using Entitas;
using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class DrawVelocityGizmoSystem : IDrawGizmoSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DrawVelocityGizmoSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Velocity,
                    GameMatcher.MovementAvailable));
        }

        public void DrawGizmo()
        {
            foreach (GameEntity entity in _entities)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(entity.WorldPosition, entity.WorldPosition + entity.Velocity.normalized);
                Gizmos.color = Color.white;
            }
        }
    }
}