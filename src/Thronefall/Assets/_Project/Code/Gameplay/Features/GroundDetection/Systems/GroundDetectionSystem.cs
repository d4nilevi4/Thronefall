using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.GroundDetection
{
    public class GroundDetectionSystem : IExecuteSystem
    {
        private readonly IGroundDetectionService _groundDetectionService;
        private readonly IGroup<GameEntity> _entities;

        public GroundDetectionSystem(GameContext game, IGroundDetectionService groundDetectionService)
        {
            _groundDetectionService = groundDetectionService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AffectedByGravity,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_groundDetectionService.TryGetRaycastResult(entity.WorldPosition, out RaycastHit raycastHit))
                {
                    entity.isGrounded = true;
                    entity.ReplaceGroundHit(raycastHit);
                }
                else
                {
                    entity.isGrounded = false;
                }
            }
        }
    }
}