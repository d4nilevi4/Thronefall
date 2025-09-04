using Thronefall.Common;

namespace Thronefall.Infrastructure
{
    public sealed class BindViewFeature : CustomFeature
    {
        public BindViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindEntityFromPathSystem>());
            Add(systemFactory.Create<BindEntityViewFromPrefab>());
        }
    }
}