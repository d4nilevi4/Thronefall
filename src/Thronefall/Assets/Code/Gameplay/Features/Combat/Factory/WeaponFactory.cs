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
        
        public GameEntity CreateWeapon(WeaponTypeId typeId, int owner)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(VectorExtensions.FarAway())
                .AddViewPath("Gameplay/Weapons/Axe/Axe_Small")
                .AddWeaponTypeId(typeId)
                .With(x => x.isWeapon = true)
                .AddWeaponOwner(owner)
                .AddTarget(owner)
                .AddPositionOffset(new Vector3(0f, 2f, 0f))
                .With(x => x.isLerpToTargetPosition = true)
                .AddSpeed(15f)
                .With(x => x.isSyncTransformPosition = true)
                .With(x => x.isMeleeWeapon = true)
                .AddAttackRadius(1.5f)
                .AddRotationSpeed(10f)
                .With(x => x.isRotateWeaponWhileAttacking = true)
                .AddDamage(new Damage() { Value = 1, })
                .AddHitLayerMask(CollisionLayer.Enemy.AsMask())
                ;
        }
    }
}