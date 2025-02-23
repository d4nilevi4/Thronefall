using Thronefall.Infrastructure;

namespace Thronefall.Common.Destruct
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systems)
        {
            Add(systems.Create<SelfDestructTimerSystem>());

            Add(systems.Create<CleanupGameDestructedSystem>());
            Add(systems.Create<CleanupInputDestructedSystem>());
        }
    }
}