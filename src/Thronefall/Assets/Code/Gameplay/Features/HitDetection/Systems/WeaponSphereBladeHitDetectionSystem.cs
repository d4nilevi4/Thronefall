using System.Collections.Generic;
using Entitas;
using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Common.EntityIndices;
using UnityEngine;

namespace Thronefall.Gameplay.HitDetection
{
    public class WeaponSphereBladeHitDetectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly ICollisionRegistry _collisionRegistry;
        private readonly IHitFactory _hitFactory;
        private readonly IGroup<GameEntity> _weapons;
        private readonly Collider[] _overlapBuffer = new Collider[10];


        public WeaponSphereBladeHitDetectionSystem(
            GameContext game,
            ICollisionRegistry collisionRegistry,
            IHitFactory hitFactory)
        {
            _game = game;
            _collisionRegistry = collisionRegistry;
            _hitFactory = hitFactory;
            _weapons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WeaponSphereBladeRadius,
                    GameMatcher.WeaponSphereBladeTransform,
                    GameMatcher.HitLayerMask));
        }

        public void Execute()
        {
            foreach (GameEntity weapon in _weapons)
            {
                GameEntity owner = _game.GetEntityWithId(weapon.WeaponOwner);

                int hitCount = 0;

                if (owner.isAttacking)
                {
                    hitCount = Physics.OverlapSphereNonAlloc(
                        position: weapon.WeaponSphereBladeTransform.position,
                        radius: weapon.WeaponSphereBladeRadius,
                        results: _overlapBuffer,
                        layerMask: weapon.HitLayerMask);
                }

                VerifyWeaponHit(weapon.Id, hitCount);
            }
        }

        private void VerifyWeaponHit(int weaponId, int hitCount)
        {
            for (int i = 0; i < hitCount; i++)
            {
                int targetId = _collisionRegistry.Get<GameEntity>(_overlapBuffer[i].GetInstanceID()).Id;

                bool tryVerifyExistingHit = TryVerifyExistingHit(weaponId, targetId);

                if (!tryVerifyExistingHit)
                    _hitFactory.CreateWeaponHit(weaponId, targetId);
            }
        }

        private bool TryVerifyExistingHit(int weaponId, int targetId)
        {
            foreach (GameEntity weaponHit in _game.TargetWeaponHits(weaponId))
            {
                if (weaponHit.Target == targetId)
                {
                    weaponHit.isVerifiedWeaponHit = true;
                    return true;
                }
            }

            return false;
        }
    }
}