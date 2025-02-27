using Entitas;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class SurfaceDetectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SurfaceDetectionSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.SlideOnSurface));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.isGrounded && entity.hasGroundHit)
                    entity.ReplaceSurfaceNormal(entity.GroundHit.normal);
                else if (entity.hasSurfaceNormal)
                    entity.RemoveSurfaceNormal();
            }
        }
    }
}