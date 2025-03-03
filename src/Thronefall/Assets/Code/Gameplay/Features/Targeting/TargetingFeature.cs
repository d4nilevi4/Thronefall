using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Targeting
{
    public sealed class TargetingFeature : Feature
    {
        public TargetingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CopyTargetPositionSystem>());
            Add(systemFactory.Create<LerpToTargetPositionSystem>());
        }
    }
}