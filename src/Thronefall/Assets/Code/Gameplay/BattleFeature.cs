using Thronefall.Common.Destruct;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}