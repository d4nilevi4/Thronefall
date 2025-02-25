using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Hero
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetHeroDirectionByInputSystem>());
            Add(systemFactory.Create<AnimateHeroMovementSystem>());
        }
    }
}