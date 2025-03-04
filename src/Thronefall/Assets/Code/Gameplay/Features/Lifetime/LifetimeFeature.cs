using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Lifetime
{
    public sealed class LifetimeFeature : CustomFeature
    {
        public LifetimeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
            
        }
    }
}