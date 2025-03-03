using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Gameplay.StaticData;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public HeroFactory(
            IIdentifierService identifierService,
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateHero(Vector3 at)
        {
            HeroConfig config = _staticDataService.GetHeroConfig();
            
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddVelocity(Vector3.zero)
                .AddDirection(Vector3.zero)
                .AddSpeed(config.Speed)
                .With(x => x.isRotateTowardsVelocity = true)
                .AddRotationSpeed(config.RotationSpeed)
                .AddViewPrefab(config.ViewPrefab)
                .With(x => x.isPhysXMovable = true)
                .With(x => x.isAffectedByGravity = true)
                .With(x => x.isSlideOnSurface = true)
                .With(x => x.isHero = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isAttacker = true)
                .With(x => x.isChooseClosestTarget = true)
                ;
        }
    }
}