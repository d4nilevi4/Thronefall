using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Rotation
{
    public class RotationTowardsVelocitySystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _rotators;

        public RotationTowardsVelocitySystem(
            GameContext game, 
            ITimeService time)
        {
            _time = time;
            _rotators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Velocity,
                    GameMatcher.RotateTowardsVelocity,
                    GameMatcher.Rigidbody,
                    GameMatcher.RotationSpeed));
        }

        public void Execute()
        {
            foreach (GameEntity rotator in _rotators)
            {
                Vector3 flatVelocity = new Vector3(rotator.Velocity.x, 0, rotator.Velocity.z);

                if (flatVelocity.sqrMagnitude > 0.001f)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(flatVelocity.normalized);
                    
                    rotator.Rigidbody.rotation = Quaternion.Slerp(
                        rotator.Rigidbody.rotation, 
                        lookRotation, 
                        _time.DeltaTime * rotator.RotationSpeed);
                }
            }
        }
    }
}