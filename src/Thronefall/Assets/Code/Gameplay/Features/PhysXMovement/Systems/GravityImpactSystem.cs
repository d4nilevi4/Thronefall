using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class GravityImpactSystem : IExecuteSystem
    {
        private const float GRAVITY = -9.8f;
        
        private readonly IGroup<GameEntity> _entities;

        public GravityImpactSystem(GameContext contextParameter)
        {
            _entities = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.PhysXMovable,
                    GameMatcher.AffectedByGravity)
                .NoneOf(
                    GameMatcher.Grounded));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Vector3 velocity = entity.Velocity;

                velocity.y += GRAVITY;

                entity.ReplaceVelocity(velocity);
            }
        }
    }
}