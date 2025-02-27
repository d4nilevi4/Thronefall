using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class CheckGroundedSystem : IExecuteSystem
    {
        private readonly IGroundDetectionService _groundDetectionService;
        private readonly IGroup<GameEntity> _entities;

        public CheckGroundedSystem(GameContext game, IGroundDetectionService groundDetectionService)
        {
            _groundDetectionService = groundDetectionService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.AffectedByGravity));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isGrounded = _groundDetectionService.IsGrounded(entity.WorldPosition);
            }
        }
    }
}