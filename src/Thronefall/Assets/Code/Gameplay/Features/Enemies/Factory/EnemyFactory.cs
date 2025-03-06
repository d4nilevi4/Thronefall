using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddVelocity(Vector3.zero)
                .AddDirection(Vector3.zero)
                .AddSpeed(2f)
                .With(x => x.isRotateTowardsVelocity = true)
                .AddRotationSpeed(5f)
                .AddViewPath("Gameplay/Skeleton/Skeleton")
                .With(x => x.isPhysXMovable = true)
                .With(x => x.isAffectedByGravity = true)
                .With(x => x.isSlideOnSurface = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isAttacker = true)
                .With(x => x.isChooseHeroTarget = true)
                .With(x => x.isAgent = true)
                .AddEnemyTypeId(typeId)
                .With(x => x.isEnemy = true)
                .AddAgentDestination(at)
                .AddMaxHp(20f)
                .AddCurrentHp(20f)
                ;
        }
    }
}