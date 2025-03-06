using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Targeting
{
    public sealed class TargetingFeature : CustomFeature
    {
        public TargetingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CopyTargetPositionSystem>());
            Add(systemFactory.Create<LerpToTargetPositionSystem>());
            
            Add(systemFactory.Create<ChooseClosestEnemyTargetSystem>());
            Add(systemFactory.Create<ChooseHeroTargetSystem>());
        }
    }
}