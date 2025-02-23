using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Movement
{
    public class SurfaceDetectionSystem : IExecuteSystem
    {
        private readonly ISurfaceDetectionService _surfaceDetectionService;

        private readonly IGroup<GameEntity> _entities;

        public SurfaceDetectionSystem(GameContext game, ISurfaceDetectionService surfaceDetectionService)
        {
            _surfaceDetectionService = surfaceDetectionService;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.SlideOnSurface));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_surfaceDetectionService.TryGetSurfaceNormal(entity.WorldPosition, out Vector3 surfaceNormal))
                    entity.ReplaceSurfaceNormal(surfaceNormal);
                else if (entity.hasSurfaceNormal)
                    entity.RemoveSurfaceNormal();
            }
        }
    }
}