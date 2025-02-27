using Entitas;
using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class DrawVelocityGizmoSystem : IDrawGizmoSystem
    {
        private readonly IGroundDetectionService _groundDetectionService;
        private readonly IGroup<GameEntity> _entities;

        public DrawVelocityGizmoSystem(GameContext game, IGroundDetectionService groundDetectionService)
        {
            _groundDetectionService = groundDetectionService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Velocity,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable));
        }

        public void DrawGizmo()
        {
            foreach (GameEntity entity in _entities)
            {
                Debug.Log("Gizmo drawing");
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(entity.WorldPosition, entity.WorldPosition + entity.Velocity.normalized);
                Gizmos.color = Color.white;
            }
        }
    }
}