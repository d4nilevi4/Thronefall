using Thronefall.Common;
using Thronefall.Common.Entity;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateHero(Vector3 at)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector3.zero)
                .AddSpeed(2f)
                .AddViewPath("Gameplay/Hero/HeroView")
                // .With(x => x.isSlideOnSurface = true)
                .With(x => x.isHero = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}