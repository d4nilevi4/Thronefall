using Entitas;
using Thronefall.Common;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class CheckGroundDrawGizmoSystem : IDrawGizmoSystem
    {
        private readonly IGroundDetectionService _groundDetectionService;
        private readonly IGroup<GameEntity> _entities;

        public CheckGroundDrawGizmoSystem(GameContext game, IGroundDetectionService groundDetectionService)
        {
            _groundDetectionService = groundDetectionService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.AffectedByGravity));
        }

        public void DrawGizmo()
        {
            foreach (GameEntity entity in _entities)
            {
                // if (_groundDetectionService.TryGetSurfaceNormal(entity.WorldPosition, out Vector3 surfaceNormal))
                // {
                //     // Gizmos.DrawLine(entity.WorldPosition, );
                // }
            }
        }
    }
}