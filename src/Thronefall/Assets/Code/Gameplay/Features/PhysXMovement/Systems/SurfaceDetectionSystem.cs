using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class SurfaceDetectionSystem : IExecuteSystem
    {
        private readonly IGroundDetectionService _groundDetectionService;

        private readonly IGroup<GameEntity> _entities;

        public SurfaceDetectionSystem(GameContext game, IGroundDetectionService groundDetectionService)
        {
            _groundDetectionService = groundDetectionService;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.SlideOnSurface));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_groundDetectionService.TryGetSurfaceNormal(entity.WorldPosition, out Vector3 surfaceNormal))
                    entity.ReplaceSurfaceNormal(surfaceNormal);
                else if (entity.hasSurfaceNormal)
                    entity.RemoveSurfaceNormal();
            }
        }
    }
}