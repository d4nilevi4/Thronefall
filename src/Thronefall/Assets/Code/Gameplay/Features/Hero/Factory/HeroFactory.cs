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
                .AddDirection(Vector3.zero)
                .AddSpeed(config.Speed)
                .AddViewPrefab(config.ViewPrefab)
                .With(x => x.isSlideOnSurface = true)
                .With(x => x.isHero = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}