using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class AdjustVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movables;

        public AdjustVelocitySystem(GameContext game)
        {
            _movables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.PhysXMovable,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (GameEntity movable in _movables)
            {
                if (movable.isMovementAvailable)
                    movable.Rigidbody.linearVelocity = movable.Velocity;
                else
                    movable.Rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }
}