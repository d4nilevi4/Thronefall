using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Navigation
{
    public sealed class NavigationFeature : Feature
    {
        public NavigationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetAgentDestinationSystem>());
            Add(systemFactory.Create<SetAgentDirectionByNavigationSystem>());
        }
    }
}