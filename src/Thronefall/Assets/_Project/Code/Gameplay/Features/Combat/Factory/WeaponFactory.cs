using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IIdentifierService _identifierService;
        
        public WeaponFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateWeapon(
            WeaponConfig weaponConfig, 
            int owner, 
            int targetLayerMask)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(VectorExtensions.FarAway())
                .AddViewPrefab(weaponConfig.View)
                .AddWeaponTypeId(weaponConfig.WeaponTypeId)
                .With(x => x.isWeapon = true)
                .AddWeaponOwner(owner)
                .AddTarget(owner)
                .AddPositionOffset(weaponConfig.Offset)
                .With(x => x.isLerpToTargetPosition = true)
                .AddSpeed(15f)
                .With(x => x.isSyncTransformPosition = true)
                .With(x => x.isMeleeWeapon = true)
                .AddAttackRadius(weaponConfig.AttackRadius)
                .AddRotationSpeed(weaponConfig.RotationSpeed)
                .With(x => x.isRotateWeaponWhileAttacking = true)
                .AddDamage(weaponConfig.Damage)
                .AddHitLayerMask(targetLayerMask)
                ;
        }
    }
}