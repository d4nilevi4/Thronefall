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
        
        public GameEntity CreateEnemy(EnemyConfig enemyConfig, Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddVelocity(Vector3.zero)
                .AddDirection(Vector3.zero)
                .AddSpeed(enemyConfig.Speed)
                .With(x => x.isRotateTowardsVelocity = true)
                .AddRotationSpeed(enemyConfig.RotationSpeed)
                .AddViewPrefab(enemyConfig.View)
                .With(x => x.isPhysXMovable = true)
                .With(x => x.isAffectedByGravity = true)
                .With(x => x.isSlideOnSurface = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isAttacker = true)
                .With(x => x.isChooseHeroTarget = true)
                .With(x => x.isAgent = true)
                .AddEnemyTypeId(enemyConfig.EnemyTypeId)
                .With(x => x.isEnemy = true)
                .AddAgentDestination(at)
                .AddMaxHp(enemyConfig.MaxHp)
                .AddCurrentHp(enemyConfig.MaxHp)
                ;
        }
    }
}