using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Rotation
{
    public class RotateWeaponWhileAttackingSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _weapons;

        public RotateWeaponWhileAttackingSystem(GameContext game, ITimeService time)
        {
            _game = game;
            _time = time;
            _weapons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Transform,
                    GameMatcher.RotateWeaponWhileAttacking,
                    GameMatcher.RotationSpeed));
        }

        public void Execute()
        {
            foreach (GameEntity weapon in _weapons)
            {
                GameEntity owner = _game.GetEntityWithId(weapon.WeaponOwner);
                
                if(!owner.isAttacking)
                    continue;
                
                GameEntity target = _game.GetEntityWithId(owner.Target);
                
                Vector3 direction = target.WorldPosition - owner.WorldPosition;
                direction.y = 0;

                if(direction.sqrMagnitude < 0.001f)
                    continue;
                
                Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);

                weapon.Transform.rotation = Quaternion.Slerp(
                    weapon.Transform.rotation,
                    lookRotation,
                    weapon.RotationSpeed * _time.DeltaTime);
            }
        }
    }
}