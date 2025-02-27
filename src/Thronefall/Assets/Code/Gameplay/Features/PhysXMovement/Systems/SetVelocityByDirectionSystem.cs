using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.PhysXMovement
{
    public class SetVelocityByDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movables;

        public SetVelocityByDirectionSystem(GameContext game)
        {
            _movables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PhysXMovable,
                    GameMatcher.Velocity,
                    GameMatcher.Direction
                ));
        }

        public void Execute()
        {
            foreach (GameEntity movable in _movables)
            {
                if(movable.isMoving)
                    movable.ReplaceVelocity(movable.Direction);
                else
                    movable.ReplaceVelocity(Vector3.zero);
            }
        }
    }
}