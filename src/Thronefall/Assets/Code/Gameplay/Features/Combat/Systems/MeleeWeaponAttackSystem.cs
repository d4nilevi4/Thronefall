using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class MeleeWeaponAttackSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _weapons;

        public MeleeWeaponAttackSystem(GameContext game)
        {
            _game = game;
            
            _weapons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.MeleeWeapon,
                    GameMatcher.WeaponOwner,
                    GameMatcher.AttackRadius));
        }

        public void Execute()
        {
            foreach (GameEntity weapon in _weapons)
            {
                GameEntity owner = _game.GetEntityWithId(weapon.WeaponOwner);
                
                if(!owner.hasTarget)
                {
                    owner.isAttacking = false;
                    continue;
                }

                GameEntity target = _game.GetEntityWithId(owner.Target);
                
                if(Vector3.Distance(target.WorldPosition, owner.WorldPosition) > weapon.AttackRadius)
                {
                    owner.isAttacking = false;
                    continue;
                }
                
                owner.isAttacking = true;
            }
        }
    }
}