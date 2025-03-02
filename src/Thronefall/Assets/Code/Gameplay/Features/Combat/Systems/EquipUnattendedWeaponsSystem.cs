using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class EquipUnattendedWeaponsSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _weapons;
        private readonly List<GameEntity> _buffer = new(32);

        public EquipUnattendedWeaponsSystem(GameContext game)
        {
            _game = game;
            _weapons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WeaponTypeId,
                    GameMatcher.WeaponOwner)
                .NoneOf(
                    GameMatcher.Equipped));
        }

        public void Execute()
        {
            foreach (GameEntity weapon in _weapons.GetEntities(_buffer))
            {
                GameEntity weaponOwner = _game.GetEntityWithId(weapon.WeaponOwner);
                weaponOwner.AddEquippedWeapon(weapon.Id);
                weapon.isEquipped = true;
            }
        }
    }
}