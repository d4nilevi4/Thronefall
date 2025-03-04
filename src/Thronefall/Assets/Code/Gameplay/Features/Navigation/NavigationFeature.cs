using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Navigation
{
    public sealed class NavigationFeature : CustomFeature
    {
        public NavigationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetAgentDestinationSystem>());
            Add(systemFactory.Create<SetAgentDirectionByNavigationSystem>());
        }
    }
}